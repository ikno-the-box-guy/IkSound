using System.Text.Json.Serialization;

namespace IkSound.Models.Epidemic;

public class CoverArt
{
    [JsonPropertyName("baseUrl")]
    public string BaseUrl { get; set; }

    [JsonPropertyName("sizes")]
    public Sizes Sizes { get; set; }
}