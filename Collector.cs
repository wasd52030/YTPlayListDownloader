using System.Text.Json;
using YoutubeExplode;

namespace YTPlayListDownloader.Collectors;

abstract class Collector
{
    // reference -> https://github.com/Tyrrrz/YoutubeExplode
    protected YoutubeClient yt;
    protected string url;

    public Collector(string url)
    {
        yt = new YoutubeClient();
        this.url = url;
    }

    public abstract Task Invoke();

    public virtual string RemoveSpecialChar(string input)
    {
        foreach (var item in new string[] { @"*", @"/", "\n", "\"", "|", ":", "?", "*" })
        {
            input = input.Replace(item, "");
        }

        return input;
    }

    public static async
        Task<(string id, string title, string owner, List<YoutubeExplode.Playlists.PlaylistVideo> videos)>
        GetPlayListInfo(string url)
    {
        var yt = new YoutubeClient();
        var playlist = await yt.Playlists.GetAsync(url);
        var VideoList = await yt.Playlists.GetVideosAsync(url).ToListAsync();


        return (playlist.Id, playlist.Title, playlist.Author?.ChannelTitle!, VideoList);
    }

    public static async Task<Videos> GetCustomTitle()
    {
        string jsonFile =
            await File.ReadAllTextAsync(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "./customTitle.json"));

        return JsonSerializer.Deserialize<Videos>(
            jsonFile,
            new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
        )!;
    }
}