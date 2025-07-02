using ObiletApp.Models.Dtos.Shared;
using System.Text.Json.Serialization;

namespace ObiletApp.Models.Dtos;

public class SessionResponseDTO
{
    [JsonPropertyName("api-request-id")]
    public string? ApiRequestId { get; set; }

    [JsonPropertyName("client-request-id")]
    public string? ClientRequestId { get; set; }

    [JsonPropertyName("controller")]
    public string? Controller { get; set; }

    [JsonPropertyName("correlation-id")]
    public string? CorrelationId { get; set; }

    [JsonPropertyName("data")]
    public SessionData? Data { get; set; }

    [JsonPropertyName("message")]
    public string? Message { get; set; }

    [JsonPropertyName("parameters")]
    public object? Parameters { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }

    [JsonPropertyName("user-message")]
    public string? UserMessage { get; set; }

    [JsonPropertyName("web-correlation-id")]
    public string? WebCorrelationId { get; set; }
}
