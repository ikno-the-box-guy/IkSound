using System.Text.Json.Serialization;

namespace IkSound.Models.Epidemic.Sfx;

public class SfxGenreRoot
{
    [JsonPropertyName("genres")]
    public List<SfxGenre> Genres { get; set; }

    [JsonPropertyName("moods")]
    public List<object> Moods { get; set; }
}