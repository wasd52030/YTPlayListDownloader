# YTPlayListDownloader-C#

如標題所言，是用C#寫的Youtube播放清單下載器，基於[這位大老寫的yt library](https://github.com/Tyrrrz/YoutubeExplode)

會寫這個是因為以前用python寫的在某些狀態下會下載失敗，而且要使用它還需要載python interpreter，再用pip裝所需要的套件，感覺還是有點麻煩，雖然有技術可以把python程式做成執行檔，不過總感覺其執行效率堪憂na。

基於前面的原因，期末讀一讀就跑來搞這玩意了，以後要用的話只要載.net6 runtime，~~之後點開執行檔就完事了，舒服~~現在要下command了，差低。

對了，dotnet在開源之後寫起來真滴舒服XD

## usage
- download: 下載給定的播放清單網址中所有的影片，並將名稱、youtube video id寫入`customName.json`，方便往後查閱、自訂
  - parameters:  	
    - --pl: youtube播放清單網址，預設值為
  - Command Example
    - dotnet run download --pl youtubePlaylistURL
    - YTPlayListDownloader download --pl youtubePlaylistURL
- check : 查閱下載下來的東西跟`customName.json`裡面紀錄的東西的差異
	- Command Example
		- dotnet run check
		-  YTPlayListDownloader check
  
-  stat : 從`customName.json`中統計影片貢獻者(contributor，可以是歌手、演奏家、內容創作者等等)
   - contributor 以中括號的形式標註在`customName.json`的影片紀錄中的title欄位，contributor 跟影片標題以空格分開
     - Example
        ```json
        {
          "id": "youtube video id",
          "title": "[contributor1][contributor2] video title",
          "comment": null
        }
        ```
   - Command Example
     - dotnet run stat
     -  YTPlayListDownloader stat

**本專案有加 github actions 做 contributor 統計自動更新，在動程式之前記得做 pull 之類的動作**
