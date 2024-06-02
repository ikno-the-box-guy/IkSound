using System.Text.Json.Serialization;

namespace IkSound.Models.Epidemic;

public class Max
{
    [JsonPropertyName("value")]
    public int Value { get; set; }
}