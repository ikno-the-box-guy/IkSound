using System.Text.Json.Serialization;

namespace IkSound.Models.Epidemic;

public class Tag
{
    [JsonPropertyName("key")]
    public string Key { get; set; }

    [JsonPropertyName("count")]
    public int Count { get; set; }

    [JsonPropertyName("displayKey")]
    public string DisplayKey { get; set; }
}