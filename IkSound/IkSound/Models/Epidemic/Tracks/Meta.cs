using System.Text.Json.Serialization;

namespace IkSound.Models.Epidemic;

public class Meta
{
    [JsonPropertyName("term")]
    public string Term { get; set; }

    [JsonPropertyName("hits")]
    public List<Hit> Hits { get; set; }

    [JsonPropertyName("duration")]
    public int Duration { get; set; }

    [JsonPropertyName("totalHits")]
    public int TotalHits { get; set; }

    [JsonPropertyName("totalPages")]
    public int TotalPages { get; set; }

    [JsonPropertyName("aggregations")]
    public Aggregations Aggregations { get; set; }
}