using System.Text.Json.Serialization;
using ObiletApp.Models.Dtos.Shared;

namespace ObiletApp.Models.Dtos;

public class JourneyRequestDTO
{
    [JsonPropertyName("device-session")]
    public DeviceSession? DeviceSession { get; set; }
    public string? Date { get; set; }
    public string? Language { get; set; }
    public BusJourneyData? Data { get; set; }
}


