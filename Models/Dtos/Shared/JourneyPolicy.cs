using System.Text.Json.Serialization;

namespace ObiletApp.Models.Dtos.Shared;

public class JourneyPolicy
{
    [JsonPropertyName("max-seats")]
    public object? MaxSeats { get; set; }

    [JsonPropertyName("max-single")]
    public object? MaxSingle { get; set; }

    [JsonPropertyName("max-single-males")]
    public object? MaxSingleMales { get; set; }

    [JsonPropertyName("max-single-females")]
    public object? MaxSingleFemales { get; set; }

    [JsonPropertyName("mixed-genders")]
    public bool MixedGenders { get; set; }

    [JsonPropertyName("gov-id")]
    public bool GovId { get; set; }

    public bool Lht { get; set; }
}
