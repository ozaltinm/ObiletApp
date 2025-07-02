using System.Text.Json.Serialization;
using ObiletApp.Models.Dtos.Shared;

namespace ObiletApp.Models.Dtos
{
    public class JourneyResponseDTO
    {
        [JsonPropertyName("status")]
        public string? Status { get; set; }

        [JsonPropertyName("data")]
        public List<JourneyResponseData>? Data { get; set; }

        [JsonPropertyName("message")]
        public string? Message { get; set; }

        [JsonPropertyName("user-message")]
        public string? UserMessage { get; set; }

        [JsonPropertyName("api-request-id")]
        public string? ApiRequestId { get; set; }

        [JsonPropertyName("controller")]
        public string? Controller { get; set; }
    }
}
