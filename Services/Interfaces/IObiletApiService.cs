using ObiletApp.Models.Dtos;
using ObiletApp.Models.Dtos.Shared;

namespace ObiletApp.Services.Interfaces;

public interface IObiletApiService{
    
    Task<SessionData> GetSessionAsync(SessionRequestDTO sessionRequest);
    
    Task<List<JourneyResponseData>> GetJourneys(JourneyRequestDTO request);
    
    Task<BusLocationResponseDTO> GetBusLocations(BusLocationRequestDTO request);
    
}

