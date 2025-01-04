using System.Text;
using FFMpegCore;
using YTPlayListDownloader.Collectors;

class LocalDurationDiff : Collector
{
    public LocalDurationDiff(string url) : base(url)
    {
    }

    public override async Task Invoke()
    {
        var playListInfo = await GetPlayListInfo(url);

        var playList = await yt.Playlists.GetVideosAsync("https://www.youtube.com/playlist?list=PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip")
                                 .Select(async playlistVideo =>
                                 {
                                     var video = await yt.Videos.GetAsync(playlistVideo.Url);

                                     return (video.Title, video.Duration);
                                 })
                                 .ToListAsync();

        string path = $"D:\\source-codes\\ytPlaylistDownloader\\YT-{playListInfo.title}";

        var mp3_files = Directory.GetFiles(path)
                                 .Select( mp3Path =>
                                 {
                                     var mp3 = TagLib.File.Create(mp3Path);

                                     var mediaInfo =  FFProbe.Analyse(mp3Path);

                                     return (mp3.Tag.Track, mp3.Tag.Title, mp3.Properties.Duration);
                                 })
                                 .ToList();


        using (var report = File.Create("./LengthDiffReport.csv"))
        {
            
            for (int i = 0; i < playList.Count; i++)
            {
                var p = await playList[i];
                var m = mp3_files.Where(item => item.Track == i + 1).FirstOrDefault();

                var message=$"{i+1:000}, {p.Title}, Youtube與檔案長度差異:\t{p.Duration - m.Duration}\n";
                byte[] info = new UTF8Encoding(true).GetBytes(message);
                Console.WriteLine(message);
                report.Write(info, 0, info.Length);
            }
        }

        Console.WriteLine("ok!");
    }
}