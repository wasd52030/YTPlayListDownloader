using System.ComponentModel.DataAnnotations;

namespace YTPlayListDownloader.Models;

public record PlayList(string Id, string Title, string Author)
{
    public virtual ICollection<PlayListVideos>? PlaylistVideos { get; set; }
}