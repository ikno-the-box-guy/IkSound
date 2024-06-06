using System.Text.Json.Serialization;

namespace IkSound.Models.Epidemic;

public class Genre
{
    [JsonPropertyName("tag")]
    public string Tag { get; set; }

    [JsonPropertyName("fatherTag")]
    public string FatherTag { get; set; }

    [JsonPropertyName("displayTag")]
    public string DisplayTag { get; set; }

    [JsonPropertyName("slug")]
    public string Slug { get; set; }

    [JsonPropertyName("key")]
    public string Key { get; set; }

    [JsonPropertyName("count")]
    public int Count { get; set; }

    [JsonPropertyName("displayKey")]
    public string DisplayKey { get; set; }

    public override string ToString()
    {
        return DisplayTag;
    }
}