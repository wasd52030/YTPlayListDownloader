using System.Diagnostics;
using YoutubeExplode.Playlists;
using YTPlayListDownloader.Collectors;

class LocalVideoUpdater : Collector
{
    public LocalVideoUpdater(string url) : base(url)
    {
    }


    public override async Task Invoke()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Stopwatch watch = new Stopwatch();
        Stopwatch fileWatch = new Stopwatch();
        watch.Start();

        var playListInfo = await GetPlayListInfo(url);
        var Videos = (await GetCustomTitle()).items;

        string name = $"YT-{playListInfo.title}";

        if (!Directory.Exists($"./{name}"))
        {
            throw new DirectoryNotFoundException($"{name} not found!");
        }

        Directory.SetCurrentDirectory($"./{name}");
        Console.WriteLine(Directory.GetCurrentDirectory());

        foreach (var file in Directory.GetFiles("."))
        {
            fileWatch.Restart();

            var filename = Path.GetFileNameWithoutExtension(file);
            var ext = Path.GetExtension(file);
            var video = Videos.FirstOrDefault(v => v.Title.Contains(filename));

            if (video != null)
            {
                if (video.Playlists.Count > 0)
                {
                    var mp3Stream = await video.GetMp3Stream(file);
                    var youtubeCover = await video.getPictureStream(video.CoverUrl);

                    mp3Stream = await mp3Stream.AnnotateTag(video, playListInfo.id, youtubeCover);
                    using var fileStream = File.Create($"{filename}.mp3");
                    await mp3Stream.CopyToAsync(fileStream);
                }
            }

            var message = $"{file.Split('/').Last()} Update ☑ {fileWatch.Elapsed}";
            Console.WriteLine(message);

            fileWatch.Stop();
        }

        watch.Stop();
        Console.WriteLine($"執行時間: {watch.Elapsed}");
    }
}