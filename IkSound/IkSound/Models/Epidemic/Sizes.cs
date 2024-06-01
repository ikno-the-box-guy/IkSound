using System.Text.Json.Serialization;

namespace IkSound.Models.Epidemic;

public class Sizes
{
    [JsonPropertyName("XS")]
    public string XS { get; set; }

    [JsonPropertyName("S")]
    public string S { get; set; }

    [JsonPropertyName("M")]
    public string M { get; set; }

    [JsonPropertyName("L")]
    public string L { get; set; }
}