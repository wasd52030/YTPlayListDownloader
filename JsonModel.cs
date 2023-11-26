using System.Text.Json.Serialization;

class Videos
{
    [JsonPropertyName("videos")]
    public List<Video> videos { get; set; }
}



class Video
{

    [JsonPropertyName("id")]
    public string id { get; set; }

    [JsonPropertyName("name")]
    public string name { get; set; }

    public Video(string id, string name)
    {
        this.id = id;
        this.name = name;
    }

    public override string ToString()
    {
        return $"id={id}, name={name}";
    }
}