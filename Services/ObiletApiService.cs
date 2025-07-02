using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

using ObiletApp.Services.Interfaces;
using ObiletApp.Models.Dtos;
using ObiletApp.Models.Dtos.Shared;
using ObiletApp.Options;
using Microsoft.Extensions.Options;

namespace ObiletApp.Services;

public class ObiletApiService : IObiletApiService
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<ObiletApiService> _logger;
    private readonly ObiletApiOptions   _opts;

    public ObiletApiService(HttpClient httpClient, ILogger<ObiletApiService> logger,   IOptions<ObiletApiOptions> opts)
    {
        _httpClient = httpClient;
        _logger = logger;
        _opts       = opts.Value;

        _httpClient.BaseAddress = new Uri(_opts.BaseUrl);
        _httpClient.DefaultRequestHeaders.Clear();
        _httpClient.DefaultRequestHeaders.Add("Authorization", $"Basic {_opts.Token}");
        _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
    }

    public async Task<SessionData> GetSessionAsync(SessionRequestDTO sessionRequest)
    {

        var jsonBody = JsonSerializer.Serialize(sessionRequest);
        var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

        var response = await _httpClient.PostAsync("client/getsession", content);
        response.EnsureSuccessStatusCode();

        var responseJson = await response.Content.ReadAsStringAsync();
        var session = JsonSerializer.Deserialize<SessionResponseDTO>(responseJson,
            new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });

        if (session?.Data != null)
        {
            return session.Data;
        }

        throw new Exception("Session could not be created.");
    }

    public async Task<BusLocationResponseDTO> GetBusLocations(BusLocationRequestDTO request)
    {
        var jsonBody = JsonSerializer.Serialize(request);
        var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

        var response = await _httpClient.PostAsync("location/getbuslocations", content);
        response.EnsureSuccessStatusCode();

        var responseJson = await response.Content.ReadAsStringAsync();
        var busLocations = JsonSerializer.Deserialize<BusLocationResponseDTO>(responseJson);

        if (busLocations != null)
        {
            return busLocations;
        }

        throw new Exception("Bus locations could not be retrieved.");

    }

    public async Task<List<JourneyResponseData>> GetJourneys(JourneyRequestDTO request)
    {
        var jsonBody = JsonSerializer.Serialize(request);
        var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

        var response = await _httpClient.PostAsync("journey/getbusjourneys", content);
        response.EnsureSuccessStatusCode();

        var responseJson = await response.Content.ReadAsStringAsync();
        var journeys = JsonSerializer.Deserialize<JourneyResponseDTO>(responseJson);

        return journeys?.Data ?? new List<JourneyResponseData>();
    }

}
