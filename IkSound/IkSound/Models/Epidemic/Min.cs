using System.Text.Json.Serialization;

namespace IkSound.Models.Epidemic;

public class Min
{
    [JsonPropertyName("value")]
    public int Value { get; set; }
}