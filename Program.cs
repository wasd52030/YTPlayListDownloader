using YoutubeExplode;
using YoutubeExplode.Videos.Streams;
using YoutubeExplode.Playlists;
using System.Text.Json;
using System.Text.Encodings.Web;
using System.Text.Unicode;

string removeSpecialChar(string input)
{
    foreach (var item in new string[] { @"*", @"/", "\n", "\"", "|", ":", "?" })
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

async Task<int> download(YoutubeClient yt, List<PlaylistVideo> list, int playListLength, int count = 0, int explodeCount = 0)
{

    string jsonFile = await File.ReadAllTextAsync(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "./customName.json"));
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
        var vtitle = removeSpecialChar(vinfo.Title);
        var vId = vinfo.Id;
        try
        {
            count++;
            var v = jsonContent.videos.FirstOrDefault(v => v.id == vinfo.Id);
            vtitle = v != null ? v.name : vtitle;
            if (File.Exists($@"./{vtitle}.mp3"))
            {

                list.Remove(list[0]);
                Console.WriteLine($"{vtitle} ok！\n{count}/{playListLength}\n");
            }
            else
            {
                if (v == null)
                {
                    jsonContent.videos.Add(new Video(vId, vtitle));
                }


                var videolist = await yt.Videos.Streams.GetManifestAsync(list[0].Url);
                var videoInfo = videolist.GetAudioOnlyStreams().GetWithHighestBitrate();
                await yt.Videos.Streams.DownloadAsync(videoInfo, $@"./{vtitle}.mp3");
                Console.WriteLine($"{vtitle} ok！\n{count}/{playListLength}\n");
                list.Remove(list[0]);
            }
            await Task.Delay(250);

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
    await File.WriteAllTextAsync("./customName.json", finalJson);

    return explodeCount;
}

//reference -> https://csharpkh.blogspot.com/2017/10/c-async-void-async-task.html
async Task main()
{
    Console.OutputEncoding = System.Text.Encoding.UTF8;

    var t1 = DateTime.UtcNow;
    // reference -> https://github.com/Tyrrrz/YoutubeExplode
    var yt = new YoutubeClient();

    string url = "https://www.youtube.com/playlist?list=PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip";
    var playListInfo = await getPlayListInfo(yt, url);
    Console.Write(
        $"請輸入Youtube PlayList網址，預設為{playListInfo["owner"].Replace("by", "").Trim()}的{playListInfo["title"]}: "
    );
    string? userInput = Console.ReadLine();
    string name = $"YT-{playListInfo["title"]}";

    if (!string.IsNullOrEmpty(userInput))
    {
        url = userInput;
        playListInfo = await getPlayListInfo(yt, url);
        name = $"YT-{playListInfo["title"]}";
    }
    name = removeSpecialChar(name);

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

await main();
