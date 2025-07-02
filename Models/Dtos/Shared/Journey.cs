using System.Text.Json.Serialization;

namespace ObiletApp.Models.Dtos.Shared;

public class Journey
{
    public string? Kind { get; set; }
    public string? Code { get; set; }
    public List<JourneyStop>? Stops { get; set; }
    public string? Origin { get; set; }
    public string? Destination { get; set; }
    public DateTime Departure { get; set; }
    public DateTime Arrival { get; set; }
    public string? Currency { get; set; }
    public string? Duration { get; set; }

    [JsonPropertyName("original-price")]
    public decimal OriginalPrice { get; set; }

    [JsonPropertyName("internet-price")]
    public decimal InternetPrice { get; set; }

    public object? Booking { get; set; }

    [JsonPropertyName("bus-name")]
    public string? BusName { get; set; }

    public JourneyPolicy? Policy { get; set; }
    public List<string>? Features { get; set; }
    public object? Description { get; set; }
    public object? Available { get; set; }
}