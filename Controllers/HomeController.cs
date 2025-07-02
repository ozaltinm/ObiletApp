using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ObiletApp.Models.Dtos;
using ObiletApp.Models.ViewModels;
using ObiletApp.Models.Dtos.Shared;
using ObiletApp.Helpers.Interfaces;
using ObiletApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Caching.Memory;



namespace ObiletApp.Controllers;

public class HomeController : Controller
{
    private readonly ISessionManager _sessionManager;
    private readonly IObiletApiService _obiletApiService;
    public HomeController(ISessionManager sessionManager, IObiletApiService obiletApiService)
    {
        _sessionManager = sessionManager;
        _obiletApiService = obiletApiService;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        // 1) Get session and location values
        var (sessionId, deviceId) = await _sessionManager.GetSessionAsync();
        var resp = await _obiletApiService.GetBusLocations(new BusLocationRequestDTO
        {
            Data = null,
            DeviceSession = new DeviceSession { SessionId = sessionId, DeviceId = deviceId },
            Date = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss"),
            Language = "tr-TR"
        });
        var allLocations = resp.Data?.ToList() ?? new List<BusLocationData>();

        if (!allLocations.Any())
        {
            // if there is no location, return empty model
            var emptyVm = new SearchViewModel
            {
                SelectedOriginId = null,
                SelectedDestinationId = null,
                JourneyDate = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd"),
                Origins = allLocations,
                Destinations = allLocations
            };
            return View(emptyVm);
        }

        // default values
        var originId = allLocations.FirstOrDefault()?.Id;
        var destinationId = allLocations.Skip(2).FirstOrDefault()?.Id;

        // ViewModel basic values
        var vm = new SearchViewModel
        {
            SelectedOriginId = originId,
            SelectedDestinationId = destinationId,
            JourneyDate = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd"),
            Origins = allLocations,
            Destinations = allLocations
        };

        // Fill values of SelectListItem 
        vm.OriginItems = allLocations
            .Select(o => new SelectListItem
            {
                Value = o.Id.ToString(),
                Text = o.Name,
                Selected = o.Id == vm.SelectedOriginId
            });

        vm.DestinationItems = allLocations
            .Select(o => new SelectListItem
            {
                Value = o.Id.ToString(),
                Text = o.Name,
                Selected = o.Id == vm.SelectedDestinationId
            });

        return View(vm);
    }

    [HttpPost]
    public async Task<IActionResult> Index(SearchViewModel model)
    {
        // get session values
        var (sid, did) = await _sessionManager.GetSessionAsync();

        // fill DTO
        var req = new JourneyRequestDTO {
            DeviceSession = new DeviceSession { SessionId = sid, DeviceId = did },
            Date          = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss"),
            Language      = "tr-TR",
            Data          = new BusJourneyData {
                OriginId      = model.SelectedOriginId,
                DestinationId = model.SelectedDestinationId,
                DepartureDate = model.JourneyDate
            }
        };

        // call API 
        var resp = await _obiletApiService.GetJourneys(req);

        // ViewModel mapping
        var vm = new JourneySearchResultViewModel {
            OriginId       = model.SelectedOriginId,
            DestinationId  = model.SelectedDestinationId,
            JourneyDate    = model.JourneyDate
        };

        if (resp != null)
        {
            vm.Journeys = resp.Select(j => new JourneyViewModel {
                Id                  = j.Id,
                PartnerName         = j.PartnerName ?? "",
                BusType             = j.Journey?.BusName ?? j.BusType ?? "",
                Departure           = j.Journey?.Departure ?? DateTime.MinValue,
                Arrival             = j.Journey?.Arrival   ?? DateTime.MinValue,
                InternetPrice       = j.Journey?.InternetPrice ?? 0,
                OriginLocation      = j.OriginLocation      ?? "",
                DestinationLocation = j.DestinationLocation ?? ""
            }).ToList();
        }

         return View("Results", vm);
    }

}