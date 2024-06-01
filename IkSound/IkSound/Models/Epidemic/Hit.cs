using System.Text.Json.Serialization;

namespace IkSound.Models.Epidemic;

public class Hit
{
    [JsonPropertyName("trackId")]
    public int TrackId { get; set; }

    [JsonPropertyName("stemType")]
    public string StemType { get; set; }

    [JsonPropertyName("matchedQueries")]
    public List<object> MatchedQueries { get; set; }
}