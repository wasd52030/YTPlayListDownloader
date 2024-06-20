using YoutubeExplode;
using YoutubeExplode.Videos.Streams;
using YoutubeExplode.Converter;
using YoutubeExplode.Playlists;
using System.Text.Json;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using System.Text.RegularExpressions;
using System.Diagnostics;
using YoutubeExplode.Videos;

class Download : Collector
{
    public Download(string url) : base(url) { }

    private void AnnotateMp3Tag(string filePath, string vTitle, string? comment)
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

    /// <summary>
    /// youtube現在好像有可能會卡這類影片的自動下載，可以考慮直接跳過(現有的相關檔案要備份R)
    /// </summary>
    // {"id": "87moOXPTtSk","title": "[-inai-][可不] 死のうとしたのにな"}
    // {"id": "4QXCPuwBz2E","title": "[ツユ] あの世行きのバスに乗ってさらば"}
    // {"id": "0_pfGRDugxg","title": "[Rap Battle!] Light Yagami vs Monika"}
    private bool CheckSpecialVideo(VideoId videoId)
    {
        string[] special = new string[] { "4QXCPuwBz2E", "87moOXPTtSk", "0_pfGRDugxg" };

        return special.Contains(videoId.ToString());
    }

    private bool IsNeedReStereo(VideoId videoId)
    {
        string[] special = new string[] { "QJq6GAZYH18" };

        return special.Contains(videoId.ToString());
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
            Stream res;

            var vinfo = await yt.Videos.GetAsync(list[0].Url);
            var vtitle = vinfo.Title;
            var vId = vinfo.Id;

            try
            {
                count++;
                var v = jsonContent?.items.FirstOrDefault(v => v.Id == vinfo.Id);
                vtitle = RemoveSpecialChar(v?.Title ?? vtitle);
                var filePath = $@"./{vtitle.Split("]").Last().Trim()}.mp3";

                // 可能會炸的檢查，看以後有沒有辦法做到選擇性把下面的片段(Line 90-98)編譯進去
                if (CheckSpecialVideo(vId))
                {
                    watch.Stop();
                    Console.WriteLine($"[{count:D4}/{playListLength:D4}] {filePath.Split('/').Last()} ☑ {watch.Elapsed}");
                    Console.WriteLine($"[{count:D4}/{playListLength:D4}] Due to uncontrollable factors such as YouTube policies, downloading is temporarily unavailable.");
                    Console.WriteLine($"[{count:D4}/{playListLength:D4}] Please make backups in advance, or seek alternative services for downloading.");
                    list.Remove(list[0]);
                    continue;
                }


                if (File.Exists(filePath))
                {
                    watch.Stop();

                    AnnotateMp3Tag(filePath, vtitle, v?.comment);
                    list.Remove(list[0]);
                    var message = $"[{count:D4}/{playListLength:D4}] {filePath.Split('/').Last()} ☑ {watch.Elapsed}";
                    Console.WriteLine(message);
                }
                else
                {
                    if (v == null)
                    {
                        jsonContent?.items.Add(new Video(vId, vtitle, null));
                    }

                    // await yt.Videos.DownloadAsync(
                    //     vId,
                    //     new ConversionRequestBuilder(filePath)
                    //     .SetContainer(Container.Mp3)
                    //     .SetPreset(ConversionPreset.Medium)
                    //     .Build()
                    // );
                    // Console.WriteLine($"adding {filePath.Split('/').Last()}'s tag......");
                    // AnnotateMp3Tag(filePath, vtitle, v?.comment);

                    var videotManifest = await yt.Videos.Streams.GetManifestAsync(vId);
                    var videoInfo = videotManifest.GetAudioOnlyStreams()
                                                  .GetWithHighestBitrate();

                    if (IsNeedReStereo(vId))
                    {
                        var ReStereoStopwatch = new Stopwatch();
                        ReStereoStopwatch.Start();

                        res = (await videoInfo.GetReStereoMp3Stream(1)).AnnotateMp3Tag(vtitle, v?.comment);
                        Console.WriteLine($"[{count:D4}/{playListLength:D4}] {filePath.Split('/').Last()} ReStereo ☑ {ReStereoStopwatch.Elapsed}");

                        ReStereoStopwatch.Stop();
                    }
                    else
                    {
                        res = (await videoInfo.GetMp3Stream()).AnnotateMp3Tag(vtitle, v?.comment);
                    }

                    using var fileStream = File.Create(filePath);
                    res.CopyTo(fileStream);

                    watch.Stop();
                    var message = $"[{count:D4}/{playListLength:D4}] {filePath.Split('/').Last()} Download ☑ {watch.Elapsed}";
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