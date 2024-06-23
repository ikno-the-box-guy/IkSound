using System.Text.Json.Serialization;

namespace IkSound.Models.Epidemic.Sfx;

public class Mood
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("fatherMoodId")]
    public int? FatherMoodId { get; set; }

    [JsonPropertyName("tag")]
    public string Tag { get; set; }

    [JsonPropertyName("displayTag")]
    public string DisplayTag { get; set; }

    [JsonPropertyName("slug")]
    public string Slug { get; set; }
}