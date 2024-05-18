using YoutubeExplode;
abstract class Collector
{
    // // reference -> https://github.com/Tyrrrz/YoutubeExplode
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

    public static async Task<Dictionary<string, string>> GetPlayListInfo(string url)
    {
        var yt = new YoutubeClient();
        var playlist = await yt.Playlists.GetAsync(url);
        Dictionary<string, string> info = new Dictionary<string, string>
        {
            { "title", playlist.Title },
            { "owner", playlist.Author?.ChannelTitle! }
        };
        return info;
    }
}