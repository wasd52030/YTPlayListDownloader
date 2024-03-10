using YoutubeExplode;
using YoutubeExplode.Videos.Streams;
using YoutubeExplode.Converter;
using YoutubeExplode.Playlists;
using System.Text.Json;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using System.Text.RegularExpressions;
using System.CommandLine;

string removeSpecialChar(string input)
{
    foreach (var item in new string[] { @"*", @"/", "\n", "\"", "|", ":", "?", "*" })
    {
        input = input.Replace(item, "");
    }

    return input;
}

async Task<Dictionary<string, string>> getPlayListInfo(YoutubeClient yt, string url)
{
    var playlist = await yt.Playlists.GetAsync(url);
    Dictionary<string, string> info = new Dictionary<string, string>
    {
        { "title", playlist.Title },
        { "owner", playlist.Author?.ChannelTitle! }
    };
    return info;
}

void annotateMp3Tag(string filePath, string vTitle, string? comment)
{
    string pattern = @"\[(.*?)\]";
    var matches = Regex.Matches(vTitle, pattern);

    if (matches.Any())
    {
        try
        {
            var contributors = matches.Select(match => match.Groups[1].Value);

            TagLib.Id3v2.Tag.DefaultVersion = 4;
            TagLib.Id3v2.Tag.ForceDefaultVersion = true;

            using TagLib.File mp3 = TagLib.File.Create(filePath);
            mp3.Tag.Performers = contributors.ToArray();
            if (comment != null)
            {
                mp3.Tag.Comment = comment;
            }
            mp3.Save();
        }
        catch (System.Exception e)
        {
            Console.WriteLine(e);
        }
    }

}

async Task<int> download(YoutubeClient yt, List<PlaylistVideo> list, int playListLength, int count = 0, int explodeCount = 0)
{

    string jsonFile = await File.ReadAllTextAsync(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "./customTitle.json"));
    var jsonContent = JsonSerializer.Deserialize<Videos>(
        jsonFile,
        new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
    );

    if (list.Count == 0)
    {
        return explodeCount;
    }

    while (list.Count > 0)
    {
        var vinfo = await yt.Videos.GetAsync(list[0].Url);
        var vtitle = vinfo.Title;
        var vId = vinfo.Id;

        try
        {
            count++;
            var v = jsonContent?.items.FirstOrDefault(v => v.id == vinfo.Id);
            vtitle = removeSpecialChar(v?.title ?? vtitle);
            var filePath = $@"./{vtitle.Split("]").Last().Trim()}.mp3";
            if (File.Exists(filePath))
            {
                annotateMp3Tag(filePath, vtitle, v?.comment);
                list.Remove(list[0]);
                Console.WriteLine($"{vtitle} ok！\n{count}/{playListLength}\n");
            }
            else
            {
                if (v == null)
                {
                    jsonContent?.items.Add(new Video(vId, vtitle, null));
                }

                await yt.Videos.DownloadAsync(
                    vId,
                    new ConversionRequestBuilder(filePath)
                    .SetContainer(Container.Mp3)
                    .SetPreset(ConversionPreset.Medium)
                    .Build()
                );
                Console.WriteLine($"adding {filePath.Split('/').Last()}'s tag......");
                annotateMp3Tag(filePath, vtitle, v?.comment);
                Console.WriteLine($"{filePath.Split('/').Last()} ok！\n{count}/{playListLength}\n");
                list.Remove(list[0]);
            }
            // await Task.Delay(250);

            // Console.WriteLine(jsonContent.videos.Last());
        }
        catch (System.Exception e)
        {
            Console.WriteLine(e);
            Console.WriteLine("Boom！");
            Console.WriteLine($"explodeCount: {explodeCount + 1}\n");
            return await download(yt, list, playListLength, count - 1, explodeCount + 1);
        }
    }

    if (jsonContent != null)
    {
        jsonContent.items.Sort((Video a, Video b) =>
        {
            return a.title.CompareTo(b.title);
        });

        var finalJson = JsonSerializer.Serialize<Videos>(
            jsonContent,
            new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.All)
            }
        );

        // current directory is in download folder
        // return to root directory for overwrite data
        Directory.SetCurrentDirectory($"../");
        await File.WriteAllTextAsync("./customTitle.json", finalJson);
    }

    return explodeCount;
}

//reference -> https://csharpkh.blogspot.com/2017/10/c-async-void-async-task.html
async Task downloadMain(string url)
{
    Console.OutputEncoding = System.Text.Encoding.UTF8;

    var t1 = DateTime.UtcNow;
    // reference -> https://github.com/Tyrrrz/YoutubeExplode
    var yt = new YoutubeClient();

    // string url = "https://www.youtube.com/playlist?list=PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip";
    var playListInfo = await getPlayListInfo(yt, url);

    string name = $"YT-{playListInfo["title"]}";

    if (!Directory.Exists($"./{name}"))
    {
        Directory.CreateDirectory($"./{name}");
    }
    Directory.SetCurrentDirectory($"./{name}");



    var playList = await yt.Playlists.GetVideosAsync(url).ToListAsync();
    var explodeCount = await download(yt, playList, playList.Count);
    Console.WriteLine($"共炸了{explodeCount}次");

    var t2 = DateTime.UtcNow;
    Console.WriteLine($"執行時間: {t2 - t1}");
}


async Task checkMain(string url)
{
    Console.OutputEncoding = System.Text.Encoding.UTF8;

    // reference -> https://github.com/Tyrrrz/YoutubeExplode
    var yt = new YoutubeClient();

    // string url = "https://www.youtube.com/playlist?list=PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip";
    var playListInfo = await getPlayListInfo(yt, url);

    string name = $"YT-{playListInfo["title"]}";

    var mp3s = Directory.GetFiles(name).Select(m => m.Split('\\').Last().Split(".").First());


    string jsonFile = await File.ReadAllTextAsync(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "./customTitle.json"));
    var jsonContent = JsonSerializer.Deserialize<Videos>(
        jsonFile,
        new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
    );

    var v = jsonContent!.items.Select(v => v.title.Split("]").Last().Trim());

    var diff = v.Except(mp3s);

    // Console.WriteLine($"[\n{string.Join(",\n", diff)}\n]");
    Console.WriteLine("[");
    foreach (var item in diff) { Console.WriteLine($"  {item},"); }
    Console.WriteLine("]");
}

async Task Main()
{
    // root command
    var rootCommand = new RootCommand("youtube播放清單下載");

    // download command
    var downloadCommand = new Command(name: "download", description: "下載");

    var playlistOption = new Option<string>
    (aliases: new string[] { "--playlist", "--pl" },
    description: "youtube playlist url",
    getDefaultValue: () => "https://www.youtube.com/playlist?list=PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip");

    downloadCommand.Add(playlistOption);
    rootCommand.AddCommand(downloadCommand);

    downloadCommand.SetHandler(async (playlistOption) =>
    {
        Console.WriteLine(playlistOption);
        await downloadMain(playlistOption);
    }, playlistOption);

    // check command
    var statCommand = new Command(name: "check", description: "檢查")
    {
        playlistOption
    };
    rootCommand.AddCommand(statCommand);
    statCommand.SetHandler(async (playlistOption) =>
    {
        await checkMain(playlistOption);
    }, playlistOption);

    await rootCommand.InvokeAsync(args);
}

await Main();





