using System.Text.Json.Serialization;

namespace IkSound.Models.Epidemic;

public class Stem
{
    [JsonPropertyName("stemType")]
    public string StemType { get; set; }

    [JsonPropertyName("s3TrackId")]
    public int S3TrackId { get; set; }

    [JsonPropertyName("lqMp3Url")]
    public string LqMp3Url { get; set; }

    [JsonPropertyName("waveformUrl")]
    public string WaveformUrl { get; set; }
}