using System.Text.Json.Serialization;

namespace ObiletApp.Models.Dtos.Shared;

public class Connection
{
    [JsonPropertyName("ip-address")]
    public string? IpAddress { get; set; }
    public string? Port { get; set; }
}