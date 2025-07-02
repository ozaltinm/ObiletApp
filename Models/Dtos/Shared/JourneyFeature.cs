using System.Text.Json.Serialization;

namespace ObiletApp.Models.Dtos.Shared;

public class JourneyFeature
{
    public int Id { get; set; }
    public int Priority { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }

    [JsonPropertyName("is-promoted")]
    public bool IsPromoted { get; set; }

    [JsonPropertyName("back-color")]
    public string? BackColor { get; set; }

    [JsonPropertyName("fore-color")]
    public string? ForeColor { get; set; }
}
