using System.Text.Json;
using System.Text.Encodings.Web;
using System.Text.RegularExpressions;
using Plotly.NET.ImageExport;
using Plotly.NET;

class DataAnalysis
{
    public static async Task Invoke()
    {
        string jsonFile = await File.ReadAllTextAsync(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "./customTitle.json"));
        var jsonContent = JsonSerializer.Deserialize<Videos>(
            jsonFile,
            new JsonSerializerOptions
            {
                WriteIndented = true,
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            }
        );

        // reference -> https://ithelp.ithome.com.tw/articles/10195017
        // reference -> https://brooke2010.github.io/2015/03/11/linq-query/
        var videoContributor = jsonContent!.items
        .SelectMany(v =>
        {
            string pattern = @"\[(.*?)\]";
            var matches = Regex.Matches(v.Title, pattern);
            return matches.Any() ? matches.Cast<Match>().Select(m => m.Groups[1].Value) : new[] { "unknown" };
        });

        var baseSeq = videoContributor.GroupBy(contributor => contributor)
                                      .OrderByDescending(item => item.Count())
                                      .ThenBy(item => item.Key.Length)
                                      .ThenBy(item => item.Key);


        await MakeJSON(baseSeq);
        MakePieChart(baseSeq);
    }

    static async Task MakeJSON(IOrderedEnumerable<IGrouping<string, string>> baseSeq)
    {
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
    }

    static void MakePieChart(IOrderedEnumerable<IGrouping<string, string>> baseSeq)
    {
        var plotSeq = baseSeq.Where(item => item.Key != "unknown")
                         .Select(item => new { key = item.Key, count = item.Count() })
                         .GroupBy(item => item.count)
                         .Select(item =>
                         {
                             var seq = item.Select(item => item);

                             var detail = string.Join(
                                             ", ",
                                            seq.Select(item => item.key)
                                               .OrderBy(item => item.Length)
                                               .ThenBy(item => item)
                                               .Take(3)
                                        );

                             // https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/functional/pattern-matching
                             // https://dog0416.blogspot.com/2020/02/c-80-pattern-matching-enhancements.html
                             string s = seq.Count() switch
                             {
                                 > 3 => $"[{item.Key}*{seq.Count()} = {item.Key * seq.Count()}] {detail}, ... 等{seq.Count()}位",
                                 > 1 => $"[{item.Key}*{seq.Count()} = {item.Key * seq.Count()}] {detail}",
                                 1 => $"[{item.Key}] {detail}",
                                 _ => "" // seq.Count() 在此幾乎保證大於等於1，因此其餘狀況回傳空字串
                             };

                             var m = item.Count() * item.Key;
                             return (s, m);
                         })
                         .Concat(
                            baseSeq.Where(item => item.Key == "unknown")
                                   .Select(item => ($"[{item.Count()}] {item.Key}", item.Count()))
                            )
                         .ToDictionary(item => item.Item1, item => (double)item.Item2);

        
        var doughnut = Plotly.NET.CSharp.Chart.Doughnut<double, string, string>(
            values: plotSeq.Select(item => item.Value).ToList(),
            Labels: plotSeq.Select(item => item.Key).ToList()
        );

        doughnut.WithTitle("statistics of contributors")
           .SavePNG("contributorStat", Width: 700, Height: 450);
    }
}