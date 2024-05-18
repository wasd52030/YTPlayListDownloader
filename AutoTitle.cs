using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using YoutubeExplode;

class AutoTitle : Collector
{
    public AutoTitle(string url) : base(url) { }

    private async Task<List<Video>> Update(List<Video> videos)
    {
        var playList = await yt.Playlists.GetVideosAsync(url).ToListAsync();
        var newVideos = playList.Where(playList => !videos.Any(video => video.Id == playList.Id))
                                .Select(video => new Video(video.Id, video.Title, ""))
                                .Concat(videos)
                                .ToList();
                                
        Console.WriteLine($"origin = {videos.Count()}, updated = {newVideos.Count()}");
        return newVideos;
    }

    public override async Task Invoke()
    {
        Console.WriteLine("updating...");

        string jsonFile = await File.ReadAllTextAsync(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "./customTitle.json"));
        var jsonContent = JsonSerializer.Deserialize<Videos>(
            jsonFile,
            new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
        );

        jsonContent.items = await Update(jsonContent.items);

        if (jsonContent != null)
        {
            jsonContent.items.Sort((Video a, Video b) =>
            {
                return a.Title.CompareTo(b.Title);
            });

            var finalJson = JsonSerializer.Serialize<Videos>(
                jsonContent,
                new JsonSerializerOptions { WriteIndented = true, Encoder = JavaScriptEncoder.Create(UnicodeRanges.All) }
            );

            await File.WriteAllTextAsync("./customTitle.json", finalJson);
        }

        Console.WriteLine("update successful");
    }
}