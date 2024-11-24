#r "nuget: YoutubeExplode, 6.4.4"
#r "nuget: System.Linq.Async, 6.0.1"
#r "nuget: TagLibSharp, 2.3.0"

using System.Text;
using YoutubeExplode;

var yt = new YoutubeClient();
var playList = await yt.Playlists.GetVideosAsync("https://www.youtube.com/playlist?list=PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip")
                                 .Select(async playlistVideo =>
                                 {
                                     var video = await yt.Videos.GetAsync(playlistVideo.Url);

                                     return (video.Title, video.Duration);
                                 })
                                 .ToListAsync();


string path = "D:\\source-codes\\ytPlaylistDownloader\\YT-BBBGGGMMM";

var mp3_files = Directory.GetFiles(path)
                         .Select(mp3Path =>
                         {
                             var mp3 = TagLib.File.Create(mp3Path);

                             return (mp3.Tag.Track, mp3.Tag.Title, mp3.Properties.Duration);
                         })
                         .ToList();


using (var report = File.Create("./LengthDiffReport.txt"))
{
    for (int i = 0; i < playList.Count; i++)
    {
        var p = await playList[i];
        var m = mp3_files.Where(item => item.Track == i + 1).FirstOrDefault();

        var message = $"{m.Track:000} Youtube與檔案長度差異:\t{p.Duration - m.Duration}\n";
        byte[] info = new UTF8Encoding(true).GetBytes(message);
        report.Write(info, 0, info.Length);
    }
}

Console.WriteLine("ok!");