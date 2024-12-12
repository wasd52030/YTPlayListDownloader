using System.Text.Json.Serialization;

public class Videos
{
    [JsonPropertyName("videos")] public HashSet<Video> items { get; set; }
}

public class PlaylistInfo : IEquatable<PlaylistInfo>
{
    [JsonPropertyName("id")] public string Id { get; set; }

    [JsonPropertyName("owner")] public string Owner { get; set; }

    [JsonPropertyName("title")] public string Title { get; set; }

    [JsonPropertyName("position")] public int Position { get; set; }

    public PlaylistInfo(string id, string owner, string title, int position)
    {
        Id = id;
        Owner = owner;
        Title = title;
        Position = position;
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }

    public override bool Equals(object? obj)
    {
        if ((obj == null) || !(obj is PlaylistInfo)) return false;
        return base.Equals(obj);
    }

    public bool Equals(PlaylistInfo? other)
    {
        if (other == null) return false;
        return Id == other.Id;
    }
}


public class Video : IEquatable<Video>
{
    [JsonPropertyName("id")] public string Id { get; set; }

    [JsonPropertyName("title")] public string Title { get; set; }


    [JsonPropertyName("comment")] public string? comment { get; set; }

    [JsonPropertyName("CoverUrl")] public string CoverUrl { get; set; }

    [JsonPropertyName("playlists")] public HashSet<PlaylistInfo> Playlists { get; set; }

    public Video(string id, string title, string? comment, string coverUrl)
    {
        Id = id;
        Title = title;
        this.comment = comment;
        Playlists = new HashSet<PlaylistInfo>();
        CoverUrl = coverUrl;
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }

    public override string ToString()
    {
        return $"{GetType().Name}(id={Id}, name={Title}, description={comment})";
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