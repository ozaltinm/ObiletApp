namespace ObiletApp.Helpers.Interfaces;

public interface ISessionManager{
    Task<(string? SessionId, string? DeviceId)> GetSessionAsync();
}