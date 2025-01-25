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
        
        // https://dotblogs.com.tw/supershowwei/2020/04/27/090746
        var locker = new SemaphoreSlim(1, 5);

        // https://stackoverflow.com/a/37569259
        var ParallelOptions = new ParallelOptions() { MaxDegreeOfParallelism = 5 };
        await Parallel.ForEachAsync(Directory.GetFiles("."), ParallelOptions, async (file, cancellationToken) =>
        {
            fileWatch.Restart();

            await Task.Delay(2000);

            // await locker.WaitAsync();

            var filename = Path.GetFileNameWithoutExtension(file);
            var ext = Path.GetExtension(file);
            var video = Videos.FirstOrDefault(v => v.Title.Split("]").Last().Trim() == filename && v.Playlists.Count > 0);

            if (video != null)
            {
                var mp3Stream = await video.GetMp3Stream(file);
                var youtubeCover = await video.getPictureStream(video.CoverUrl);

                mp3Stream = await mp3Stream.AnnotateTag(video, playListInfo.id, youtubeCover);
                using var fileStream = File.Create($"{filename}.mp3");
                await mp3Stream.CopyToAsync(fileStream);
            }

            var message = $"{file.Split('/').Last()} Update ☑ {fileWatch.Elapsed}";
            Console.WriteLine(message);

            // locker.Release();

            fileWatch.Stop();
        });

        // foreach (var file in Directory.GetFiles("."))
        // {

        // }

        watch.Stop();
        Console.WriteLine($"執行時間: {watch.Elapsed}");
    }
}