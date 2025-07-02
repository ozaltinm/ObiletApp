using System.Text.Json.Serialization;

namespace ObiletApp.Models.Dtos.Shared;

public class BusLocationData
{
   [JsonPropertyName("id")]
   public int Id { get; set; }

    [JsonPropertyName("parent-id")]
    public int ParentId { get; set; }

    public string? Type { get; set; }
    
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("geo-location")]
    public GeoLocation? GeoLocation { get; set; }

    public int Zoom { get; set; }

    [JsonPropertyName("tz-code")]
    public string? TzCode { get; set; }

    [JsonPropertyName("weather-code")]
    public string? WeatherCode { get; set; }

    public int Rank { get; set; }

    [JsonPropertyName("reference-code")]
    public string? ReferenceCode { get; set; }

    [JsonPropertyName("city-id")]
    public int CityId { get; set; }

    [JsonPropertyName("reference-country")]
    public string? ReferenceCountry { get; set; }

    [JsonPropertyName("country-id")]
    public int CountryId { get; set; }

    public string? Keywords { get; set; }

    [JsonPropertyName("city-name")]
    public string? CityName { get; set; }

    public string? Languages { get; set; }

    [JsonPropertyName("country-name")]
    public string? CountryName { get; set; }

    public string? Code { get; set; }

    [JsonPropertyName("show-country")]
    public bool ShowCountry { get; set; }

    [JsonPropertyName("area-code")]
    public string? AreaCode { get; set; }

    [JsonPropertyName("long-name")]
    public string? LongName { get; set; }

    [JsonPropertyName("is-city-center")]
    public bool IsCityCenter { get; set; }
}
