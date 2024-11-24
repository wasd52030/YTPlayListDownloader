using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace YTPlayListDownloader.Models;

public class PlayList : IEquatable<PlayList>
{
    [JsonPropertyName("id")] public string Id { get; set; }

    [JsonPropertyName("owner")] public string Owner { get; set; }

    [JsonPropertyName("title")] public string Title { get; set; }

    [JsonPropertyName("videos")]
    public virtual ICollection<PlayListVideos>? PlaylistVideos { get; set; }

    public PlayList(string id, string owner, string title)
    {
        Id = id;
        Owner = owner;
        Title = title;
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }

    public override bool Equals(object? obj)
    {
        if ((obj == null) || !(obj is PlayList)) return false;
        return base.Equals(obj);
    }

    public bool Equals(PlayList? other)
    {
        if (other == null) return false;
        return Id == other.Id;
    }
}