using YoutubeExplode.Videos.Streams;
using System.Text.RegularExpressions;
using FFMpegCore;
using FFMpegCore.Pipes;
using FFMpegCore.Enums;

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
        await ffmpeg.ProcessAsynchronously();
        res.Position = 0;

        return res;
    }

    public static async Task<Stream> SeekTo(this IStreamInfo streamInfo, TimeSpan start)
    {
        var res = new MemoryStream();

        var ffmpeg = FFMpegArguments.FromUrlInput(new Uri(streamInfo.Url))
                                    .OutputToPipe(new StreamPipeSink(res),
                                                   options =>
                                                   {
                                                       options.ForceFormat("mp3")
                                                              .Seek(start);
                                                   });
        await ffmpeg.ProcessAsynchronously();
        res.Position = 0;

        return res;
    }

    public static Stream AnnotateTag(this Stream stream, Video? playListVideoInfo, string queryId)
    {
        TagLib.Id3v2.Tag.DefaultVersion = 4;
        TagLib.Id3v2.Tag.ForceDefaultVersion = true;

        string pattern = @"\[(.*?)\]";
        var matches = Regex.Matches(playListVideoInfo.Title, pattern);

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
                file.Tag.Album = $"{p.Owner} - {p.Title}";
                file.Tag.Track = (uint)p.Position;
            }

            file.Save();
        }
        catch (System.Exception)
        {
            throw;
        }

        return stream;
    }
}