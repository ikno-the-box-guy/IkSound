using System.Text.Json.Serialization;

namespace IkSound.Models.Epidemic;

public class Aggregations
{
    [JsonPropertyName("vocals")]
    public List<Vocal> Vocals { get; set; }

    [JsonPropertyName("genres")]
    public List<Genre> Genres { get; set; }

    [JsonPropertyName("moods")]
    public List<Mood> Moods { get; set; }

    [JsonPropertyName("tags")]
    public List<Tag> Tags { get; set; }

    [JsonPropertyName("energy")]
    public List<Energy> Energy { get; set; }

    [JsonPropertyName("bpm")]
    public Bpm Bpm { get; set; }

    [JsonPropertyName("length")]
    public Length Length { get; set; }

    [JsonPropertyName("hashtags")]
    public List<Hashtag> Hashtags { get; set; }
}