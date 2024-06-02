using System.Text.Json.Serialization;

namespace IkSound.Models.Epidemic.Sfx;

public class SfxGenre
{
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("fatherGenreId")]
    public string FatherGenreId { get; set; }

    [JsonPropertyName("tag")]
    public string Tag { get; set; }

    [JsonPropertyName("displayTag")]
    public string DisplayTag { get; set; }

    [JsonPropertyName("slug")]
    public string Slug { get; set; }

    [JsonPropertyName("numTracks")]
    public int NumTracks { get; set; }
}