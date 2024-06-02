using System.Text.Json.Serialization;

namespace IkSound.Models.Epidemic;

public class Length
{
    [JsonPropertyName("min")]
    public Min Min { get; set; }

    [JsonPropertyName("max")]
    public Max Max { get; set; }
}