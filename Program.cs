//                                  |~~~~~~~|
//                                  |       |
//                                  |       |
//                                  |       |
//                                  |       |
//                                  |       |
//       |~.\\\_\~~~~~~~~~~~~~~xx~~~         ~~~~~~~~~~~~~~~~~~~~~/_//;~|
//       |  \  o \_         ,XXXXX),                         _..-~ o /  |
//       |    ~~\  ~-.     XXXXX`)))),                 _.--~~   .-~~~   |
//        ~~~~~~~`\   ~\~~~XXX' _/ ';))     |~~~~~~..-~     _.-~ ~~~~~~~
//                 `\   ~~--`_\~\, ;;;\)__.---.~~~      _.-~
//                   ~-.       `:;;/;; \          _..-~~
//                      ~-._      `''        /-~-~
//                          `\              /  /
//                            |         ,   | |
//                             |  '        /  |
//                              \/;          |
//                               ;;          |
//                               `;   .       |
//                               |~~~-----.....|
//                              | \             \
//                             | /\~~--...__    |
//                             (|  `\       __-\|
//                             ||    \_   /~    |
//                             |)     \~-'      |
//                              |      | \      '
//                              |      |  \    :
//                               \     |  |    |
//                                |    )  (    )
//                                 \  /;  /\  |
//                                 |    |/   |
//                                 |    |   |
//                                  \  .'  ||
//                                  |  |  | |
//                                  (  | |  |
//                                  |   \ \ |
//                                  || o `.)|
//                                  |`\\)   |
//                                  |       |
//                                  |       |
//                               蒙主應許 永無BUG                   

using System.CommandLine;
using YTPlayListDownloader.Collectors;

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
    var checkCommand = new Command(name: "check", description: "查詢資料庫裡面的內容與指定的播放清單內容之差異")
    {
        playlistOption
    };
    rootCommand.AddCommand(checkCommand);
    checkCommand.SetHandler(Check.Invoke, playlistOption);


    // stat command
    var statCommand = new Command(name: "stat", description: "統計影片貢獻者(contributor，可以是歌手、演奏家、內容創作者等等)")
    {
        playlistOption
    };
    rootCommand.AddCommand(statCommand);
    statCommand.SetHandler(DataAnalysis.Invoke);

    // update command
    var updateCommand = new Command(name: "update", description: "自動取得在播放清單中的影片資訊，省得手動輸入")
    {
        playlistOption
    };
    rootCommand.AddCommand(updateCommand);
    updateCommand.SetHandler(async (playlistOption) =>
    {
        var at = new AutoTitle(playlistOption);
        await at.Invoke();
    }, playlistOption);

    var updateLocalCommand = new Command(name: "local", description: "對於下載下來的檔案做檢整"){
        playlistOption
    };
    updateCommand.Add(updateLocalCommand);
    updateLocalCommand.SetHandler(async (playlistOption) =>
    {
        var u = new LocalVideoUpdater(playlistOption);
        await u.Invoke();

    }, playlistOption);


    var diffCommand = new Command(name: "diff", description: "檢查下載下來的長度是否與Youtube一致"){
        playlistOption
    };
    rootCommand.Add(diffCommand);
    diffCommand.SetHandler(async (playlistOption) =>
    {
        var u = new LocalDurationDiff(playlistOption);
        await u.Invoke();

    }, playlistOption);
    
    await rootCommand.InvokeAsync(args);
}

await Main();