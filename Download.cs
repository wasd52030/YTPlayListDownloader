using YoutubeExplode;
using YoutubeExplode.Videos.Streams;
using YoutubeExplode.Converter;
using YoutubeExplode.Playlists;
using System.Text.Json;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using System.Text.RegularExpressions;
using System.Diagnostics;

class Download : Collector
{
    public Download(string url) : base(url) { }

    private static void AnnotateMp3Tag(string filePath, string vTitle, string? comment)
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

    private async Task<int> Downlaod(List<PlaylistVideo> list, int playListLength, int count = 0, int explodeCount = 0)
    {

        string jsonFile = await File.ReadAllTextAsync(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "./customTitle.json"));
        var jsonContent = JsonSerializer.Deserialize<Videos>(
            jsonFile,
            new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
        );
        Stopwatch watch = new Stopwatch();

        if (list.Count == 0)
        {
            return explodeCount;
        }

        while (list.Count > 0)
        {
            watch.Restart();

            var vinfo = await yt.Videos.GetAsync(list[0].Url);
            var vtitle = vinfo.Title;
            var vId = vinfo.Id;

            try
            {
                count++;
                var v = jsonContent?.items.FirstOrDefault(v => v.Id == vinfo.Id);
                vtitle = RemoveSpecialChar(v?.Title ?? vtitle);
                var filePath = $@"./{vtitle.Split("]").Last().Trim()}.mp3";
                if (File.Exists(filePath))
                {
                    AnnotateMp3Tag(filePath, vtitle, v?.comment);
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
                    AnnotateMp3Tag(filePath, vtitle, v?.comment);

                    watch.Stop();
                    var message = $"[{count:D4}/{playListLength:D4}] {filePath.Split('/').Last()} ☑ {watch.Elapsed}";
                    Console.WriteLine(message);
                    list.Remove(list[0]);
                    await Task.Delay(250);
                }

            }
            catch (System.Exception e)
            {
                Console.WriteLine($"\n{e}");
                Console.WriteLine("Boom！");
                Console.WriteLine($"explodeCount: {explodeCount + 1}\n");
                return await Downlaod(list, playListLength, count - 1, explodeCount + 1);
            }
        }

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

            // current directory is in download folder
            // return to root directory for overwrite customTitle.json
            Directory.SetCurrentDirectory($"../");
            await File.WriteAllTextAsync("./customTitle.json", finalJson);
        }

        return explodeCount;
    }

    //reference -> https://csharpkh.blogspot.com/2017/10/c-async-void-async-task.html
    public override async Task Invoke()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Stopwatch watch = new Stopwatch();
        watch.Start();

        var playListInfo = await GetPlayListInfo(url);

        string name = $"YT-{playListInfo.title}";

        if (!Directory.Exists($"./{name}"))
        {
            Directory.CreateDirectory($"./{name}");
        }
        Directory.SetCurrentDirectory($"./{name}");


        var explodeCount = await Downlaod(playListInfo.videos, playListInfo.videos.Count);
        Console.WriteLine($"\n共炸了{explodeCount}次");

        watch.Stop();
        Console.WriteLine($"執行時間: {watch.Elapsed}");
    }
}