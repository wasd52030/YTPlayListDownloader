using System.Diagnostics;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

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
        string[] special = new string[] { "ry3Tupx4BL4", "87moOXPTtSk", "4QXCPuwBz2E", "0_pfGRDugxg" };

        return videos.Select(v =>
        {
            var InPlaylist = playList.FirstOrDefault((playList) => playList.Id == v.Id);
            if (InPlaylist != null)
            {
                if (special.Contains(v.Id))
                {
                    Console.WriteLine($"{playList.IndexOf(InPlaylist) + 1} - {v.Title}");
                }

                var check = v.Playlists.FirstOrDefault((playList) => playList.Id == PlaylistInfo.Id);
                if (check != null)
                {
                    v.Playlists = v.Playlists.Where(playList => playList.Id == PlaylistInfo.Id)
                                             .Select(ytAlbum =>
                                             {
                                                 ytAlbum.Position = playList.IndexOf(InPlaylist) + 1;
                                                 return ytAlbum;
                                             })
                                            .ToHashSet();
                }
                else
                {
                    var id = PlaylistInfo.Id;
                    var owner = PlaylistInfo.Author?.ChannelTitle!.Replace("by", "").Trim();
                    var title = PlaylistInfo.Title;
                    var track = playList.IndexOf(InPlaylist) + 1;
                    v.Playlists.Add(new PlaylistInfo(id, owner, title, track));
                }
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