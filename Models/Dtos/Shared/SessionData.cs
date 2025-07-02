using System.Text.Json.Serialization;

namespace ObiletApp.Models.Dtos.Shared;

public class SessionData
{
    [JsonPropertyName("affiliate")]
    public object? Affiliate { get; set; }

    [JsonPropertyName("clean-device-id")]
    public long CleanDeviceId { get; set; }

    [JsonPropertyName("clean-session-id")]
    public long CleanSessionId { get; set; }

    [JsonPropertyName("device")]
    public object? Device { get; set; }

    [JsonPropertyName("device-id")]
    public string? DeviceId { get; set; }

    [JsonPropertyName("device-type")]
    public int DeviceType { get; set; }

    [JsonPropertyName("ip-address")]
    public string? IpAddress { get; set; }

    [JsonPropertyName("ip-country")]
    public string? IpCountry { get; set; }

    [JsonPropertyName("session-id")]
    public string? SessionId { get; set; }
}