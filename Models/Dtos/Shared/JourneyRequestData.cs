using System.Text.Json.Serialization;

namespace ObiletApp.Models.Dtos.Shared;

public class BusJourneyData
{
    [JsonPropertyName("origin-id")]
    public int? OriginId { get; set; }
    [JsonPropertyName("destination-id")]
    public int? DestinationId { get; set; }
    [JsonPropertyName("departure-date")]
    public string? DepartureDate { get; set; }
}
