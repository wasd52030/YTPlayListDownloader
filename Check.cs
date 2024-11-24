using System.Text.Json;
using System.Text.Encodings.Web;
using YTPlayListDownloader.Collectors;

class Check
{
    public static async Task Invoke(string url)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        var playListInfo = await Download.GetPlayListInfo(url);

        string name = $"YT-{playListInfo.title}";

        // var mp3s = Directory.GetFiles(name).Select(m => m.Split('\\').Last().Split(".").First());


        // reference -> https://github.com/dotnet/runtime/issues/35281
        string jsonFile =
            await File.ReadAllTextAsync(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "./customTitle.json"));
        var jsonContent = JsonSerializer.Deserialize<Videos>(
            jsonFile,
            new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            }
        );

        // var v = jsonContent!.items.Select(v => v.Title.Split("]").Last().Trim());
        var LocalVideos = jsonContent!.items.Select(v => v.Id);
        var RemoteVideos = playListInfo.videos.Select(v => v.Id.ToString());

        var LDiff = LocalVideos.Except(RemoteVideos)
            .Select(i => jsonContent.items.FirstOrDefault(v => i == v.Id));

        var RDiff = RemoteVideos.Except(LocalVideos)
            .Select(i => playListInfo.videos.FirstOrDefault(v => v.Id == i));


        Console.WriteLine("On Local View");
        LDiff.Print();
        Console.WriteLine("");

        Console.WriteLine("On Remote View");
        RDiff.Print();
        Console.WriteLine("");
    }
}