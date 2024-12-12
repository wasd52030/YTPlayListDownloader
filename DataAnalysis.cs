using System.Text.Json;
using System.Text.Encodings.Web;
using System.Text.RegularExpressions;
using Plotly.NET.ImageExport;
using Plotly.NET;
using ScottPlot;

class DataAnalysis
{
    public static async Task Invoke()
    {
        string jsonFile =
            await File.ReadAllTextAsync(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "./customTitle.json"));
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
        // reference -> https://stackoverflow.com/questions/5179341/a-lambda-expression-with-a-statement-body-cannot-be-converted-to-an-expression
        var videoContributor = jsonContent!.items
            .SelectMany(v =>
            {
                string pattern = @"\[(.*?)\]";
                var matches = Regex.Matches(v.Title, pattern);
                return matches.Any() ? matches.Select(m => m.Groups[1].Value) : new[] { "unknown" };
            });

        var baseSeq = videoContributor.GroupBy(contributor => contributor)
            .OrderByDescending(item => item.Count())
            .ThenBy(item => item.Key.Length)
            .ThenBy(item => item.Key)
            .ToList();


        await MakeJson(baseSeq);
        MakeChart(baseSeq);
    }

    static async Task MakeJson(List<IGrouping<string, string>> baseSeq)
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

    static void MakeChart(List<IGrouping<string, string>> baseSeq)
    {
        var plotSeq = baseSeq.Where(item => item.Key != "unknown")
            .Select(item => new { key = item.Key, count = item.Count() })
            .GroupBy(item => item.count)
            .Select(item =>
            {
                // var seq = item.Select(item => item);

                var detail = string.Join(
                    ", ",
                    item.Select(item => item.key)
                        .OrderBy(item => item.Length)
                        .ThenBy(item => item)
                        .Take(3)
                );

                // https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/functional/pattern-matching
                // https://dog0416.blogspot.com/2020/02/c-80-pattern-matching-enhancements.html
                string s = item.Count() switch
                {
                    > 3 => $"[{item.Key}*{item.Count()} = {item.Key * item.Count()}] {detail}, ... 等{item.Count()}位",
                    > 1 => $"[{item.Key}*{item.Count()} = {item.Key * item.Count()}] {detail}",
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
            .ToList();

        #region Plotly.NET

        // Plotly.NET
        var doughnut = Plotly.NET.CSharp.Chart.Doughnut<double, string, string>(
            values: plotSeq.Select(item => (double)item.Item2).ToList(),
            Labels: plotSeq.Select(item => item.Item1).ToList()
        );

        // reference -> https://stackoverflow.com/questions/72504275/make-chart-fill-size-of-browser-window
        doughnut.WithTitle("statistics of contributors")
            .WithConfig(Config.init(Responsive: true))
            .SavePNG("contributorStat", Width: 1200, Height: 800);

        #endregion


        #region ScottPlot

        // ScottPlot
        // var myplot = new ScottPlot.Plot();
        //
        // double total = plotSeq.Select(x => x.Item2).Sum();
        // var slices = plotSeq.Select(item =>
        //                     {
        //                         var slice = new PieSlice(
        //                             item.Item2,
        //                             new ScottPlot.Color(string.Format("#{0:X6}", Guid.NewGuid().ToString().Substring(0, 6))),
        //                             $"{item.Item2 / total * 100:0.0}%"
        //                         );
        //
        //                         slice.LabelFontSize = 20;
        //                         slice.LabelBold = true;
        //                         slice.LabelFontColor = new ScottPlot.Color("#ffffff");
        //
        //                         slice.LegendText = item.Item1;
        //
        //                         return slice;
        //                     })
        //                     .ToList();
        // var pie = myplot.Add.Pie(slices);
        //
        // pie.DonutFraction = .6;
        // pie.SliceLabelDistance = 0.8;
        //
        //
        // myplot.Axes.Frameless();
        // myplot.HideAxesAndGrid();
        // // 目前沒辦法假名+漢字
        // myplot.Font.Automatic();
        // myplot.ShowLegend(Edge.Right);
        //
        // myplot.SavePng("contributorStat.png", 1200, 800);

        #endregion
    }
}