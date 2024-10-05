using YoutubeExplode.Videos.Streams;
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
    /// <para>
    /// youtube現在好像有可能會卡這類影片的自動下載，可以考慮直接跳過(現有的相關檔案要備份R)
    /// </para>
    /// <para>
    /// 作者似乎也能設定擋下載 (YoutubeExplode.Exceptions.VideoUnplayableException: Video 'videoId' is unplayable. Reason: 'Playback on other websites has been disabled by the video owner')
    /// </para>
    /// </summary>
    // {"id": "ry3Tupx4BL4","title": "[ヨルシカ] パレード"}
    // {"id": "87moOXPTtSk","title": "[-inai-][可不] 死のうとしたのにな"}
    // {"id": "4QXCPuwBz2E","title": "[ツユ] あの世行きのバスに乗ってさらば"}
    // {"id": "0_pfGRDugxg","title": "[Rap Battle!] Light Yagami vs Monika"}
    private bool IsSpecialVideo(VideoId videoId)
    {
        string[] suicide  = new string[] { "ry3Tupx4BL4", "87moOXPTtSk", "4QXCPuwBz2E", "0_pfGRDugxg" };
        string[] unplayable = new string[] { "Ej0DA0BgbRU" };

        return unplayable.Contains(videoId.ToString());
    }

    private bool IsNeedReStereo(VideoId videoId)
    {
        string[] special = new string[] { "QJq6GAZYH18" };

        return special.Contains(videoId.ToString());
    }

    private async Task<bool> DownloadVideo(string queryPlayListId, PlaylistVideo Video, Videos? CustomVideoTitles)
    {

        var vinfo = await yt.Videos.GetAsync(Video.Url);
        var vtitle = vinfo.Title;
        var vId = vinfo.Id;
        var PlaylistId = Video.PlaylistId;
        Stream Mp3Stream = new MemoryStream();

        var CustomVideoTitle = CustomVideoTitles?.items.FirstOrDefault(v => v.Id == vinfo.Id);
        vtitle = RemoveSpecialChar(CustomVideoTitle?.Title ?? vtitle);
        var filePath = $@"./{vtitle.Split("]").Last().Trim()}.mp3";

        // 可能會炸的檢查
        if (IsSpecialVideo(vId))
        {
            return false;
        }

        try
        {
            var videotManifest = await yt.Videos.Streams.GetManifestAsync(vId);
            var videoInfo = videotManifest.GetAudioOnlyStreams()
                                          .GetWithHighestBitrate();


            if (IsNeedReStereo(vId))
            {
                if (vId == "QJq6GAZYH18")
                {
                    Mp3Stream = (await videoInfo.GetReStereoMp3Stream(1)).AnnotateMp3Tag(CustomVideoTitle, queryPlayListId);
                    await Task.Delay(1500);
                    Console.WriteLine($"{filePath.Split('/').Last()} ReStereo ☑");
                }
            }
            else
            {
                Mp3Stream = (await videoInfo.GetMp3Stream()).AnnotateMp3Tag(CustomVideoTitle, queryPlayListId);
                await Task.Delay(1500);
            }

            using var fileStream = File.Create(filePath);
            await Mp3Stream.CopyToAsync(fileStream);
            await Task.Delay(1500);
            return true;
        }
        catch (System.Exception)
        {
            throw;
        }
    }

    private async Task<int> DownlaodList(string queryPlayListId, List<PlaylistVideo> list, int playListLength, int count = 0, int explodeCount = 0)
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
            var v = jsonContent?.items.FirstOrDefault(v => v.Id == vinfo.Id);

            try
            {
                count++;
                vtitle = RemoveSpecialChar(v?.Title ?? vtitle);
                var filePath = $@"./{vtitle.Split("]").Last().Trim()}.mp3";

                // 可能會炸的檢查，看以後有沒有辦法做到選擇性把下面的片段(Line 90-98)編譯進去
                if (IsSpecialVideo(vId))
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

                    // AnnotateMp3Tag(filePath, vtitle, v?.comment);
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

                        res = (await videoInfo.GetReStereoMp3Stream(1)).AnnotateMp3Tag(v, queryPlayListId);
                        Console.WriteLine($"[{count:D4}/{playListLength:D4}] {filePath.Split('/').Last()} ReStereo ☑ {ReStereoStopwatch.Elapsed}");

                        ReStereoStopwatch.Stop();
                    }
                    else
                    {
                        res = (await videoInfo.GetMp3Stream()).AnnotateMp3Tag(v, queryPlayListId);
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
                return await DownlaodList(queryPlayListId, list, playListLength, count - 1, explodeCount + 1);
            }
        }

        if (jsonContent != null)
        {
            jsonContent.items = jsonContent.items.ToList().OrderBy(v => v.Title).ToHashSet();

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

    private async Task DownlaodList(string queryPlayListId, Queue<PlaylistVideo> videos)
    {
        string jsonFile = await File.ReadAllTextAsync(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "./customTitle.json"));
        var jsonContent = JsonSerializer.Deserialize<Videos>(
            jsonFile,
            new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
        );

        Stopwatch watch = new Stopwatch();

        var count = 0;
        var playListLength = videos.Count;
        Stream Mp3Stream = new MemoryStream();

        // https://stackoverflow.com/questions/10806951/how-to-limit-the-amount-of-concurrent-async-i-o-operations
        var throttler = new SemaphoreSlim(initialCount: 5);
        List<Task> DownloadTasks = new List<Task>();

        if (videos.Count == 0)
        {
            return;
        }

        while (videos.Count > 0)
        {
            var video = videos.Peek();
            var vinfo = await yt.Videos.GetAsync(video.Url);
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
                    videos.Dequeue();
                    var message = $"{filePath.Split('/').Last()} ☑ {watch.Elapsed}";
                    Console.WriteLine(message);
                }
                else
                {
                    if (v == null)
                    {
                        jsonContent?.items.Add(new Video(vId, vtitle, null));
                    }
                    await throttler.WaitAsync();

                    DownloadTasks.Add(Task.Run(async () =>
                    {
                        try
                        {
                            Stopwatch watch = Stopwatch.StartNew();
                            watch.Restart();
                            var res = await DownloadVideo(queryPlayListId, video, jsonContent);
                            watch.Stop();

                            if (res)
                            {
                                var message = $"{filePath.Split('/').Last()} Download ☑ {watch.Elapsed}";
                                Console.WriteLine(message);
                            }
                            else
                            {
                                Console.WriteLine($"{filePath.Split('/').Last()} ☑ {watch.Elapsed}");
                                Console.WriteLine($"\tDue to uncontrollable factors such as YouTube policies, downloading is temporarily unavailable.");
                                Console.WriteLine($"\tPlease make backups in advance, or seek alternative services for downloading.");
                            }
                        }
                        catch (System.Exception e)
                        {
                            Console.WriteLine($"\n{e}");
                            Console.WriteLine("Boom！");
                            throw;
                        }
                        finally
                        {
                            throttler.Release();
                        }
                    }));
                    videos.Dequeue();
                }

            }
            catch (System.Exception e)
            {
                Console.WriteLine($"\n{e}");
                Console.WriteLine("Boom！");
                continue;
            }
        }

        Task allTask = Task.WhenAll(DownloadTasks);
        try
        {
            await allTask;
        }
        catch (System.Exception e)
        {
            Console.WriteLine($"\n{e}");
            Console.WriteLine("Boom！");
            throw;
        }


        if (jsonContent != null)
        {
            jsonContent.items = jsonContent.items.ToList().OrderBy(v => v.Title).ToHashSet();

            var finalJson = JsonSerializer.Serialize<Videos>(
                jsonContent,
                new JsonSerializerOptions { WriteIndented = true, Encoder = JavaScriptEncoder.Create(UnicodeRanges.All) }
            );

            // current directory is in download folder
            // return to root directory for overwrite customTitle.json
            Directory.SetCurrentDirectory($"../");
            await File.WriteAllTextAsync("./customTitle.json", finalJson);
        }
    }


    //reference -> https://csharpkh.blogspot.com/2017/10/c-async-void-async-task.html
    public override async Task Invoke()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Stopwatch watch = new Stopwatch();
        watch.Start();

        //TODO: 研究如何繞過自殺影片限制，我只是想聽歌而已啊
        var playListInfo = await GetPlayListInfo(url);

        var videoQueue = new Queue<PlaylistVideo>(playListInfo.videos);

        string name = $"YT-{playListInfo.title}";

        if (!Directory.Exists($"./{name}"))
        {
            Directory.CreateDirectory($"./{name}");
        }
        Directory.SetCurrentDirectory($"./{name}");

        // var explodeCount = await Downlaod(playListInfo.videos, playListInfo.videos.Count);
        await DownlaodList(playListInfo.id, videoQueue);

        watch.Stop();
        Console.WriteLine($"執行時間: {watch.Elapsed}");
    }
}