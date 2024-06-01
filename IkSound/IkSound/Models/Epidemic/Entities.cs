using System.Text.Json.Serialization;

namespace IkSound.Models.Epidemic;

public class Entities
{
    [JsonPropertyName("tracks")]
    public Dictionary<string, Song> Tracks { get; set; }
}