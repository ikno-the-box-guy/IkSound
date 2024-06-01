using System.Text.Json.Serialization;

namespace IkSound.Models.Epidemic;

public class SegmentGroup
{
    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("version")]
    public string Version { get; set; }

    [JsonPropertyName("segments")]
    public List<Segment> Segments { get; set; }
}