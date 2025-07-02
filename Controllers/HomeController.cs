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
                SelectedOrigin = null,
                SelectedDestination = null,
                JourneyDate = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd"),
                Origins = allLocations,
                Destinations = allLocations
            };
            return View(emptyVm);
        }

        // default values
        var origin = allLocations.FirstOrDefault();
        var destination = allLocations.Skip(2).FirstOrDefault();

        // ViewModel basic values
        var vm = new SearchViewModel
        {
            SelectedOrigin = origin,
            SelectedDestination = destination,
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
                Selected = o.Id == vm.SelectedOrigin?.Id
            });

        vm.DestinationItems = allLocations
            .Select(o => new SelectListItem
            {
                Value = o.Id.ToString(),
                Text = o.Name,
                Selected = o.Id == vm.SelectedDestination?.Id
            });

        return View(vm);
    }

    [HttpPost]
    public async Task<IActionResult> Index(SearchViewModel model)
    {
    /*    // 1) Server-side base model state control
        if (!ModelState.IsValid)
        {
            await RepopulateSelectLists(model);
            return View(model);
        }

        // 2) Origin is equal to Destination control
        if (model.SelectedOrigin?.Name == model.SelectedDestination?.Name)
        {
            ModelState.AddModelError(string.Empty, "Kalkış ve varış noktaları aynı olamaz.");
            await RepopulateSelectLists(model);
            return View(model);
        }

        // 3) Date control: older dates can not be selected
        if (DateTime.TryParse(model.JourneyDate, out var jd) && jd.Date < DateTime.Today)
        {
            ModelState.AddModelError(nameof(model.JourneyDate), "Geçmiş bir tarih seçilemez.");
            await RepopulateSelectLists(model);
            return View(model);
        }
*/
        // 4) All validations passed → API call and view mapping
        // get session values
        var (sid, did) = await _sessionManager.GetSessionAsync();

        // DTO mapping
        var req = new JourneyRequestDTO
        {
            DeviceSession = new DeviceSession { SessionId = sid, DeviceId = did },
            Date = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss"),
            Language = "tr-TR",
            Data = new BusJourneyData
            {
                OriginId = model.SelectedOrigin?.Id,
                DestinationId = model.SelectedDestination?.Id,
                DepartureDate = model.JourneyDate
            }
        };

        // call API 
        var resp = await _obiletApiService.GetJourneys(req);

        // ViewModel mapping
        var vm = new JourneySearchResultViewModel
        {
            Origin = model.SelectedOrigin,
            Destination = model.SelectedDestination,
            JourneyDate = model.JourneyDate
        };

        if (resp != null)
        {
            vm.Journeys = resp.Select(j => new JourneyViewModel
            {
                Id = j.Id,
                Departure = j.Journey?.Departure.ToString("HH:mm") ?? "00:00",
                Arrival = j.Journey?.Arrival.ToString("HH:mm") ?? "00:00",
                InternetPrice = j.Journey?.InternetPrice ?? "O TL",
                OriginLocation = j.Journey?.Origin ?? "",
                DestinationLocation = j.Journey?.Destination ?? ""
            }).ToList();
        }

        return View("Results", vm);
    }
    
    private async Task RepopulateSelectLists(SearchViewModel model)
    {
        var (sid, did) = await _sessionManager.GetSessionAsync();
        var resp = await _obiletApiService.GetBusLocations(new BusLocationRequestDTO {
            DeviceSession = new DeviceSession { SessionId = sid, DeviceId = did },
            Date = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss"),
            Language = "tr-TR"
        });
        var all = resp.Data?.ToList() ?? new List<BusLocationData>();

        model.OriginItems = all.Select(o => new SelectListItem {
            Value = o.Id.ToString(), Text = o.Name,
            Selected = (model.SelectedOrigin?.Id == o.Id)
        });

        model.DestinationItems = all.Select(o => new SelectListItem {
            Value = o.Id.ToString(), Text = o.Name,
            Selected = (model.SelectedDestination?.Id == o.Id)
        });
    }


}