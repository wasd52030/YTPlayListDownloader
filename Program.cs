using System.CommandLine;

async Task Main()
{
    // root command
    var rootCommand = new RootCommand("youtube播放清單下載");

    var playlistOption = new Option<string>
    (aliases: new string[] { "--playlist", "--pl" },
    description: "youtube playlist url",
    getDefaultValue: () => "https://www.youtube.com/playlist?list=PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip");

    // download command
    var downloadCommand = new Command(name: "download", description: "下載")
    {
        playlistOption
    };
    rootCommand.AddCommand(downloadCommand);
    downloadCommand.SetHandler(async (playlistOption) =>
    {
        Console.WriteLine(playlistOption);
        var d = new Download(playlistOption);
        await d.Invoke();
    }, playlistOption);


    // check command
    var checkCommand = new Command(name: "check", description: "檢查")
    {
        playlistOption
    };
    rootCommand.AddCommand(checkCommand);
    checkCommand.SetHandler(async (playlistOption) => await Check.Invoke(playlistOption), playlistOption);


    // stat command
    var statCommand = new Command(name: "stat", description: "統計影片貢獻者(contributor，可以是歌手、演奏家、內容創作者等等)")
    {
        playlistOption
    };
    rootCommand.AddCommand(statCommand);
    statCommand.SetHandler(async () => await DataAnalysis.Invoke());

    await rootCommand.InvokeAsync(args);
}

await Main();
