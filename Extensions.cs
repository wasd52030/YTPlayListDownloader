using YoutubeExplode.Videos.Streams;
using System.Text.RegularExpressions;
using FFMpegCore;
using FFMpegCore.Pipes;
using TagLib.Id3v2;
using FFMpegCore.Arguments;
using System.Reflection;
using System.Diagnostics;
using Svg;
using System.Drawing;
using System.Drawing.Imaging;

public static class Extensions
{
    public static void Print<T>(this IEnumerable<T> enumerable)
    {
        Console.WriteLine("[");
        foreach (var item in enumerable)
        {
            Console.WriteLine($"  {item},");
        }

        Console.WriteLine("]");
    }

    public static async Task<Stream> GetStream(this IStreamInfo streamInfo)
    {
        var res = new MemoryStream();

        var ffmpeg = FFMpegArguments.FromUrlInput(new Uri(streamInfo.Url))
            .OutputToPipe(new StreamPipeSink(res),
                options => options.ForceFormat("mp3"));
        await ffmpeg.ProcessAsynchronously();
        res.Position = 0;

        return res;
    }

    /// <summary>
    /// Some videos have audio in only one of the two channels. Duplicating the audio from the active channel to the inactive one ensures that both channels now carry the same signal.
    /// </summary>
    /// <param name="streamInfo"></param>
    /// <param name="maintrack"></param>
    /// <returns>Stream of audio</returns>
    public static async Task<Stream> GetReStereoStream(this IStreamInfo streamInfo, int maintrack)
    {
        var res = new MemoryStream();

        var ffmpeg = FFMpegArguments.FromUrlInput(new Uri(streamInfo.Url))
            .OutputToPipe(new StreamPipeSink(res),
                options =>
                {
                    // reference -> https://hackmd.io/@kd01/HkiPmhg3d#複製聲道
                    options.ForceFormat("mp3")
                        .WithAudioFilters(filter =>
                        {
                            filter.Pan("stereo", new string[] { $"c0=c{maintrack}", $"c1=c{maintrack}" });
                        });
                });

        var ffmpegRes = await ffmpeg.ProcessAsynchronously();
        if (ffmpegRes)
        {
            res.Position = 0;
        }

        return res;
    }

    public static async Task<Stream> GetMp3Stream(this Video video, string path)
    {
        var res = new MemoryStream();

        var ffmpeg = FFMpegArguments.FromFileInput(path, true, options =>
        {
            options.WithArgument(new CustomArgument("-vn"));
        })
            .OutputToPipe(new StreamPipeSink(res),
                options =>
                {
                    options.ForceFormat("mp3");
                });

        var ffmpegRes = await ffmpeg.ProcessAsynchronously();
        if (ffmpegRes)
        {
            res.Position = 0;
        }

        return res;
    }

    public static async Task<Stream> SeekTo(this IStreamInfo streamInfo, TimeSpan? start)
    {
        var res = new MemoryStream();

        var ffmpeg = FFMpegArguments.FromUrlInput(new Uri(streamInfo.Url))
            .OutputToPipe(new StreamPipeSink(res),
                options =>
                {
                    options.ForceFormat("mp3")
                        .Seek(start);
                });

        var ffmpegRes = await ffmpeg.ProcessAsynchronously();
        if (ffmpegRes)
        {
            res.Position = 0;
        }

        return res;
    }

    public static async Task<Stream> SeekTo(this Stream stream, TimeSpan? start)
    {
        var res = new MemoryStream();

        var ffmpeg = FFMpegArguments.FromPipeInput(new StreamPipeSource(stream))
            .OutputToPipe(new StreamPipeSink(res),
                options =>
                {
                    options.ForceFormat("mp3")
                        .Seek(start);
                });

        var ffmpegRes = await ffmpeg.ProcessAsynchronously();
        if (ffmpegRes)
        {
            res.Position = 0;
        }

        return res;
    }

    public static async Task<Stream> getPictureStream(this YoutubeExplode.Videos.Video video, string PictureUrl)
    {
        using var httpClient = new HttpClient();
        httpClient.DefaultRequestHeaders.Add("Accept", "image/jpg");
        httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/111.0.0.0 Safari/537.36");

        // var Thumbnails = video.Thumbnails.OrderBy(thumbnail => thumbnail.Resolution.Width).ToList();
        // var url = Thumbnails.LastOrDefault()!.Url;
        var response = await httpClient.GetAsync(PictureUrl);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadAsStreamAsync();
    }

    public static async Task<Stream> getPictureStream(this Video video, string PictureUrl)
    {
        using var httpClient = new HttpClient();
        httpClient.DefaultRequestHeaders.Add("Accept", "image/*");
        httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/111.0.0.0 Safari/537.36");


        try
        {
            var response = await httpClient.GetAsync(PictureUrl);
            if (response.Content.Headers.GetValues("Content-Type").First().Contains("svg"))
            {
                var src = SvgDocument.Open<SvgDocument>(response.Content.ReadAsStream());
                var bitmap = src.Draw();
                return BitmapToStream(bitmap, ImageFormat.Png);
            }
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStreamAsync();
        }
        catch (System.Exception ex)
        {
            var stackTrace = new StackTrace(ex, true);
            var frame = stackTrace.GetFrame(0);
            var method = frame.GetMethod();

            Console.WriteLine($"[{method}-boom] {video}");
            Console.WriteLine(ex);
            return await getPictureStream(video, PictureUrl);
        }
    }

    public static async Task<byte[]> ToByteArray(this Stream input)
    {
        using MemoryStream ms = new MemoryStream();
        await input.CopyToAsync(ms);
        return ms.ToArray();
    }

    public static Stream BitmapToStream(this Image image, ImageFormat format)
    {
        var stream = new System.IO.MemoryStream();
        image.Save(stream, format);
        stream.Position = 0;
        return stream;
    }

    public static async Task<Stream> AnnotateTag(this Stream stream, Video? playListVideoInfo, string queryId,
        Stream youtubeCover)
    {
        TagLib.Id3v2.Tag.DefaultVersion = 4;
        TagLib.Id3v2.Tag.ForceDefaultVersion = true;

        string pattern = @"\[(.*?)\]";
        var matches = Regex.Matches(playListVideoInfo!.Title, pattern);

        try
        {
            using var file = TagLib.File.Create(new StreamFileAbstraction($"{playListVideoInfo.Title}.mp3", stream));

            var titleWithoutContributors = playListVideoInfo.Title.Split("]").Last().Trim();
            file.Tag.Title = titleWithoutContributors;

            if (matches.Any())
            {
                var contributors = matches.Select(match => match.Groups[1].Value);

                file.Tag.Performers = contributors.ToArray();
            }

            if (playListVideoInfo.comment != null)
            {
                file.Tag.Comment = playListVideoInfo.comment;
            }

            var p = playListVideoInfo.Playlists.FirstOrDefault(i => i.Id == queryId);
            if (p != null)
            {
                file.Tag.Album = $"{p.Title}";
                file.Tag.AlbumArtists = new string[] { p.Owner };
                file.Tag.Track = (uint)p.Position;
            }

            AttachmentFrame cover = new AttachmentFrame
            {
                Type = TagLib.PictureType.FrontCover,
                Description = "Cover",
                MimeType = System.Net.Mime.MediaTypeNames.Image.Png,
                Data = await youtubeCover.ToByteArray(),
                TextEncoding = TagLib.StringType.UTF16
            };
            file.Tag.Pictures = new TagLib.IPicture[] { cover };

            file.Save();
        }
        catch (System.Exception)
        {
            throw;
        }

        return stream;
    }
}