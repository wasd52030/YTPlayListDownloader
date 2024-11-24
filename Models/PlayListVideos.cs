using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YTPlayListDownloader.Models;

public class PlayListVideos
{
    public int Position { get; set; }

    public string VideoId { get; set; }
    [ForeignKey("VideoId")] public virtual Video Video { get; set; }

    public string PlayListId { get; set; }
    [ForeignKey("PlayListId")] public virtual PlayList? PlayList { get; set; }

    public override string ToString()
    {
        return $"PlayListId: {PlayListId},PlayListTitle: {PlayList.Title}, Position: {Position}" +
               $"VideoId: {VideoId}, VideoTitle: {Video.Title}";
    }
}