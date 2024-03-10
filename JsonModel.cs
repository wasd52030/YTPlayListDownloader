using System.Text.Json.Serialization;

class Videos
{
    [JsonPropertyName("videos")]
    public List<Video> items { get; set; }
}



class Video
{

    [JsonPropertyName("id")]
    public string id { get; set; }

    [JsonPropertyName("title")]
    public string title { get; set; }


    [JsonPropertyName("comment")]
    public string? comment { get; set; }

    public Video(string id, string title, string? comment)
    {
        this.id = id;
        this.title = title;
        this.comment = comment;
    }

    public override string ToString()
    {
        return $"{GetType().Name}(id={id}, name={title}, description={comment})";
    }
}