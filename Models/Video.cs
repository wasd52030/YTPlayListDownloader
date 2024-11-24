using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace YTPlayListDownloader.Models;

public class VideoR : IEquatable<Video>
{

    [JsonPropertyName("id")] public string Id { get; set; }

    [JsonPropertyName("title")] public string Title { get; set; }


    [JsonPropertyName("comment")] public string? Comment { get; set; }

    public virtual ICollection<PlayListVideos>? PlaylistVideos { get; set; }

    public VideoR(string id, string title, string? comment)
    {
        Id = id;
        Title = title;
        Comment = comment;
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }

    public override string ToString()
    {
        return $"{GetType().Name}(id={Id}, name={Title}, description={Comment})";
    }

    public override bool Equals(object? obj)
    {
        if ((obj == null) || !(obj is Video)) return false;
        return base.Equals(obj);
    }

    public bool Equals(Video? other)
    {
        return Id == other.Id;
    }
}