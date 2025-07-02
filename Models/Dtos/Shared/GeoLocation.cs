using System.Text.Json.Serialization;

namespace ObiletApp.Models.Dtos.Shared;

public class GeoLocation
{
    [JsonPropertyName("latitude")]
    public double Latitude { get; set; }

    [JsonPropertyName("longitude")]
    public double Longitude { get; set; }

    [JsonPropertyName("zoom")]
    public int Zoom { get; set; }
}
