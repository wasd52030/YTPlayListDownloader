using YoutubeExplode;
using System.Text.Json;
using System.Text.Encodings.Web;

class Check
{
    public static async Task Invoke(string url)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        var playListInfo = await Download.GetPlayListInfo(url);

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

        var v = jsonContent!.items.Select(v => v.Title.Split("]").Last().Trim());

        var diff = v.Except(mp3s);

        Console.WriteLine("[");
        foreach (var item in diff) { Console.WriteLine($"  {item},"); }
        Console.WriteLine("]");
    }
}