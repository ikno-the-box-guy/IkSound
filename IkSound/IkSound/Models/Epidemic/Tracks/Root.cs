using System.Text.Json.Serialization;

namespace IkSound.Models.Epidemic;

public class Root
{
    [JsonPropertyName("entities")]
    public Entities Entities { get; set; }

    [JsonPropertyName("meta")]
    public Meta Meta { get; set; }

    [JsonPropertyName("suggested_queries")]
    public List<object> SuggestedQueries { get; set; }
}