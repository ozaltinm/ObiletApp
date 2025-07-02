using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Net.Sockets; 
using Microsoft.Extensions.Caching.Memory;

using ObiletApp.Models.Dtos.Shared;
using ObiletApp.Helpers.Interfaces;
using Microsoft.Extensions.Logging;
using ObiletApp.Services.Interfaces;
using ObiletApp.Models.Dtos;


namespace ObiletApp.Helpers;

public class SessionManager : ISessionManager
{
    private readonly IObiletApiService _obiletApiService;
    private readonly IMemoryCache _cache;

    public SessionManager(IObiletApiService obiletApiService, IMemoryCache cache)
    {
        _obiletApiService = obiletApiService;
        _cache = cache;
    }

    public async Task<(string? SessionId, string? DeviceId)> GetSessionAsync()
    {
        if (_cache.TryGetValue("session-id", out string? sessionId) &&
            _cache.TryGetValue("device-id", out string? deviceId))
        {
            return (sessionId, deviceId);
        }

        var request = new SessionRequestDTO
        {
            Type = 7,
            Connection = new Connection
            {
                IpAddress = GetLocalIPAddress(),
                Port = "5117"
            },
            Browser = new Browser
            {
                Name = "Chrome",
                Version = "47.0.0.12"
            }
        };

        var sessionData = await _obiletApiService.GetSessionAsync(request);

        _cache.Set("session-id", sessionData.SessionId);
        _cache.Set("device-id", sessionData.DeviceId);

        return (sessionData.SessionId, sessionData.DeviceId);
    }

    private string GetLocalIPAddress()
    {
        using (var socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, 0))
        {
            socket.Connect("8.8.8.8", 65530); // Google DNS
            var endPoint = socket.LocalEndPoint as IPEndPoint;
            return endPoint?.Address.ToString() ?? "127.0.0.1";
        }
    }
}
