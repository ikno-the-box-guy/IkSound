using System.Text.Json.Serialization;

namespace IkSound.Models.Epidemic;

public class Producer
{
    [JsonPropertyName("creativeType")]
    public string CreativeType { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("slug")]
    public string Slug { get; set; }
}