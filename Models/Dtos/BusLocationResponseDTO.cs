using System.Text.Json.Serialization;
using ObiletApp.Models.Dtos.Shared;

namespace ObiletApp.Models.Dtos;

public class BusLocationResponseDTO
{
    [JsonPropertyName("status")]
    public string? Status { get; set; }

    [JsonPropertyName("data")]
    public List<BusLocationData>? Data { get; set; }

    [JsonPropertyName("message")]
    public object? Message { get; set; }

    [JsonPropertyName("user-message")]
    public object? UserMessage { get; set; }

    [JsonPropertyName("api-request-id")]
    public object? ApiRequestId { get; set; }

    [JsonPropertyName("controller")]
    public string? Controller { get; set; }

    [JsonPropertyName("client-request-id")]
    public object? ClientRequestId { get; set; }

    [JsonPropertyName("web-correlation-id")]
    public object? WebCorrelationId { get; set; }

    [JsonPropertyName("correlation-id")]
    public string? CorrelationId { get; set; }

    [JsonPropertyName("parameters")]
    public object? Parameters { get; set; }
}

