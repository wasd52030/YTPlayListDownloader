using YoutubeExplode;
using YoutubeExplode.Videos.Streams;
using YoutubeExplode.Converter;
using YoutubeExplode.Playlists;
using System.Text.Json;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using System.Text.RegularExpressions;
using System.CommandLine;
using Plotly.NET.ImageExport;
using Plotly.NET.ConfigObjects;
using Plotly.NET;

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

    try
    {
        TagLib.Id3v2.Tag.DefaultVersion = 4;
        TagLib.Id3v2.Tag.ForceDefaultVersion = true;

        using TagLib.File mp3 = TagLib.File.Create(filePath);

        if (matches.Any())
        {
            var contributors = matches.Select(match => match.Groups[1].Value);

            mp3.Tag.Performers = contributors.ToArray();
        }

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
                // Console.WriteLine($"adding {filePath.Split('/').Last()}'s tag......");
                annotateMp3Tag(filePath, vtitle, v?.comment);
                var message = $"\r[{count}/{playListLength}] {filePath.Split('/').Last()} ok！";
                Console.Write(message.PadRight(100 - message.Length));
                list.Remove(list[0]);
                await Task.Delay(250);
            }

        }
        catch (System.Exception e)
        {
            Console.WriteLine($"\n{e}");
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
            new JsonSerializerOptions { WriteIndented = true, Encoder = JavaScriptEncoder.Create(UnicodeRanges.All) }
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

    var playListInfo = await getPlayListInfo(yt, url);

    string name = $"YT-{playListInfo["title"]}";

    if (!Directory.Exists($"./{name}"))
    {
        Directory.CreateDirectory($"./{name}");
    }
    Directory.SetCurrentDirectory($"./{name}");



    var playList = await yt.Playlists.GetVideosAsync(url).ToListAsync();
    var explodeCount = await download(yt, playList, playList.Count);
    Console.WriteLine($"\n共炸了{explodeCount}次");

    var t2 = DateTime.UtcNow;
    Console.WriteLine($"執行時間: {t2 - t1}");
}


async Task checkMain(string url)
{
    Console.OutputEncoding = System.Text.Encoding.UTF8;

    // reference -> https://github.com/Tyrrrz/YoutubeExplode
    var yt = new YoutubeClient();

    var playListInfo = await getPlayListInfo(yt, url);

    string name = $"YT-{playListInfo["title"]}";

    var mp3s = Directory.GetFiles(name).Select(m => m.Split('\\').Last().Split(".").First());


    // reference -> https://github.com/dotnet/runtime/issues/35281
    string jsonFile = await File.ReadAllTextAsync(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "./customTitle.json"));
    var jsonContent = JsonSerializer.Deserialize<Videos>(
        jsonFile,
        new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
        }
    );

    var v = jsonContent!.items.Select(v => v.title.Split("]").Last().Trim());

    var diff = v.Except(mp3s);

    Console.WriteLine("[");
    foreach (var item in diff) { Console.WriteLine($"  {item},"); }
    Console.WriteLine("]");
}

async Task analysisMain()
{
    string jsonFile = await File.ReadAllTextAsync(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "./customTitle.json"));
    var jsonContent = JsonSerializer.Deserialize<Videos>(
        jsonFile,
        new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
    );

    // reference -> https://ithelp.ithome.com.tw/articles/10195017
    // reference -> https://brooke2010.github.io/2015/03/11/linq-query/
    var videoContributor = jsonContent!.items
    .SelectMany(v =>
    {
        string pattern = @"\[(.*?)\]";
        var matches = Regex.Matches(v.title, pattern);
        return matches.Any() ? matches.Cast<Match>().Select(m => m.Groups[1].Value) : new[] { "unknown" };
    });

    var baseSeq = videoContributor.GroupBy(contributor => contributor)
                                  .OrderByDescending(item => item.Count())
                                  .ThenBy(item => item.Key.Length);

    var stat = baseSeq.ToDictionary(o => o.Key, o => (double)o.Count());
    stat.Add("total", stat.Values.Sum());
    var percent = stat.ToDictionary(record => record.Key, record => record.Value / stat["total"]);

    // reference -> https://github.com/dotnet/runtime/issues/35281
    await File.WriteAllTextAsync(
        Path.Combine(Directory.GetCurrentDirectory(), $"contributorStat.json"),
        JsonSerializer.Serialize(
            new Dictionary<string, Dictionary<string, double>>() { { "統計", stat }, { "占比", percent } },
            new JsonSerializerOptions
            {
                WriteIndented = true,
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            }
        )
    );


    var plotSeq = baseSeq.Select(item => new { key = item.Key, count = item.Count() })
                         .GroupBy(item => item.count)
                         .Select(item =>
                         {
                             var seq = item.Select(item => item);
                             var s = string.Join(
                                ", ",
                                seq.Select(item => item.key)
                                   .OrderBy(item => item.Length)
                                   .ThenBy(item => item)
                                   .Take(2)
                             );

                             if (seq.Count() > 2)
                             {
                                 s = $"{s}, ... 等{seq.Count()}位";
                             }

                             var m = item.Count() * item.Key;
                             return (s, m);
                         })
                         .ToDictionary(item => item.s, item => (double)item.m);

    var pie = Plotly.NET.CSharp.Chart.Pie<double, string, string>(
        values: plotSeq.Select(item => item.Value).ToList(),
        Labels: plotSeq.Select(item => item.Key).ToList()
    );

    pie.WithTitle("詳細資訊請參考 contributorStat.json！")
       .WithConfig(
            Plotly.NET.Config.init(
                Responsive: true
            )
        )
       .SavePNG("contributorStat", Width: 700, Height: 450);
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
    var checkCommand = new Command(name: "check", description: "檢查")
    {
        playlistOption
    };
    rootCommand.AddCommand(checkCommand);
    checkCommand.SetHandler(async (playlistOption) =>
    {
        await checkMain(playlistOption);
    }, playlistOption);

    // stat command
    var statCommand = new Command(name: "stat", description: "統計影片貢獻者(contributor，可以是歌手、演奏家、內容創作者等等)")
    {
        playlistOption
    };
    rootCommand.AddCommand(statCommand);
    statCommand.SetHandler(async (playlistOption) => await analysisMain());

    await rootCommand.InvokeAsync(args);
}

await Main();





