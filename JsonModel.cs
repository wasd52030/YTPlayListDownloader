using System.Text.Json.Serialization;
using AngleSharp.Common;

class Videos
{
    [JsonPropertyName("videos")]
    public List<Video> items { get; set; }
}



class Video
{

    [JsonPropertyName("id")]
    public string id { get; set; }

    [JsonPropertyName("name")]
    public string name { get; set; }


    [JsonPropertyName("comment")]
    public string? comment { get; set; }

    public Video(string id, string name, string? comment)
    {
        this.id = id;
        this.name = name;
        this.comment = comment;
    }

    public override string ToString()
    {
        return $"{GetType().Name}(id={id}, name={name}, description={comment})";
    }
}