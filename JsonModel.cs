using System.Text.Json.Serialization;

class Videos
{
    [JsonPropertyName("videos")]
    public List<Video> items { get; set; }
}


class Video
{

    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("title")]
    public string Title { get; set; }


    [JsonPropertyName("comment")]
    public string? comment { get; set; }

    public Video(string id, string title, string? comment)
    {
        this.Id = id;
        this.Title = title;
        this.comment = comment;
    }

    public override string ToString()
    {
        return $"{GetType().Name}(id={Id}, name={Title}, description={comment})";
    }
}