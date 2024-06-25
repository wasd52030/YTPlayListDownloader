using System.Diagnostics;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using YoutubeExplode;

class AutoTitle : Collector
{
    public AutoTitle(string url) : base(url) { }

    private async Task<IEnumerable<Video>> Update(HashSet<Video> videos)
    {
        var playList = await yt.Playlists.GetVideosAsync(url).ToListAsync();
        var newVideos = playList.Where(playList => !videos.Any(video => video.Id == playList.Id))
                                .Select(video => new Video(video.Id, video.Title, ""))
                                .Concat(videos);

        Console.WriteLine($"origin = {videos.Count}, updated = {newVideos.Count()}");
        return newVideos;
    }

    private async Task<HashSet<Video>> UpdatePlayListInfo(IEnumerable<Video> videos)
    {

        var playList = await yt.Playlists.GetVideosAsync(url).ToListAsync();
        var PlaylistInfo = await yt.Playlists.GetAsync(url);
        return videos.Select(v =>
        {
            var InPlaylist = playList.FirstOrDefault((playList) => playList.Id == v.Id);
            if (InPlaylist != null)
            {
                var id = PlaylistInfo.Id;
                var owner = PlaylistInfo.Author?.ChannelTitle!.Replace("by", "").Trim();
                var title = PlaylistInfo.Title;
                var track = playList.IndexOf(InPlaylist) + 1;
                v.Playlists.Add(new PlaylistInfo(id, owner, title, track));
            }
            return v;
        })
        .ToHashSet();
    }

    public override async Task Invoke()
    {
        Console.WriteLine("updating...");

        Stopwatch watch = new Stopwatch();
        watch.Start();

        string jsonFile = await File.ReadAllTextAsync(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "./customTitle.json"));
        var jsonContent = JsonSerializer.Deserialize<Videos>(
            jsonFile,
            new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
        );

        jsonContent!.items = await UpdatePlayListInfo(await Update(jsonContent.items));

        if (jsonContent != null)
        {
            jsonContent.items = jsonContent.items.ToList().OrderBy(v => v.Title).ToHashSet();

            var finalJson = JsonSerializer.Serialize<Videos>(
                jsonContent,
                new JsonSerializerOptions { WriteIndented = true, Encoder = JavaScriptEncoder.Create(UnicodeRanges.All) }
            );

            await File.WriteAllTextAsync("./customTitle.json", finalJson);
        }

        watch.Stop();
        Console.WriteLine($"update successful ☑ {watch.Elapsed}");
    }
}