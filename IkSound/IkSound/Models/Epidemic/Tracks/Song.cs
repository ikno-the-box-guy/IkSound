using System.Text.Json.Serialization;

namespace IkSound.Models.Epidemic;

public class Song
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("title")]
    public string Title { get; set; }

    [JsonPropertyName("added")]
    public DateTime Added { get; set; }

    [JsonPropertyName("creatives")]
    public Dictionary<string, Creative[]> Creatives { get; set; }

    [JsonPropertyName("length")]
    public int Length { get; set; }

    [JsonPropertyName("bpm")]
    public int Bpm { get; set; }

    [JsonPropertyName("isSfx")]
    public bool IsSfx { get; set; }

    [JsonPropertyName("hasVocals")]
    public bool HasVocals { get; set; }

    [JsonPropertyName("hidden")]
    public bool Hidden { get; set; }

    [JsonPropertyName("publicSlug")]
    public string PublicSlug { get; set; }

    [JsonPropertyName("genres")]
    public List<Genre> Genres { get; set; }

    [JsonPropertyName("moods")]
    public List<Mood> Moods { get; set; }

    [JsonPropertyName("energyLevel")]
    public string EnergyLevel { get; set; }

    [JsonPropertyName("stems")]
    public Dictionary<string, Stem> Stems { get; set; }

    [JsonPropertyName("oldTitle")]
    public object OldTitle { get; set; }

    [JsonPropertyName("seriesId")]
    public object SeriesId { get; set; }

    [JsonPropertyName("metadataTags")]
    public List<string> MetadataTags { get; set; }

    [JsonPropertyName("isExplicit")]
    public bool IsExplicit { get; set; }

    [JsonPropertyName("isCommercialRelease")]
    public bool IsCommercialRelease { get; set; }

    [JsonPropertyName("imageUrl")]
    public string ImageUrl { get; set; }

    [JsonPropertyName("coverArt")]
    public CoverArt CoverArt { get; set; }

    [JsonPropertyName("releaseDate")]
    public DateTime ReleaseDate { get; set; }

    [JsonPropertyName("segmentGroups")]
    public List<SegmentGroup> SegmentGroups { get; set; }
}