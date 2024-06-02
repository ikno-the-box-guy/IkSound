using System.Text.Json.Serialization;

namespace IkSound.Models.Epidemic;

public class Segment
{
    [JsonPropertyName("startTime")]
    public double StartTime { get; set; }

    [JsonPropertyName("duration")]
    public double Duration { get; set; }
}