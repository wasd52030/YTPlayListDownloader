using System.ComponentModel.DataAnnotations;

namespace YTPlayListDownloader.Models;

public record Video(string Id, string Title, string? Comment)
{
    public virtual ICollection<PlayListVideos>? PlaylistVideos { get; set; }
}