using System.Text.Json.Serialization;

namespace IkSound.Models.Epidemic;

public class Vocal
{
    [JsonPropertyName("key")]
    public int Key { get; set; }

    [JsonPropertyName("count")]
    public int Count { get; set; }
}