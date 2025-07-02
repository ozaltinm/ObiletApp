using System.Collections.Generic;
using ObiletApp.Models.Dtos.Shared;

namespace ObiletApp.Models.ViewModels;

public class JourneySearchResultViewModel
{
    public List<JourneyViewModel> Journeys { get; set; } = new();
    public BusLocationData? Origin         { get; set; }
    public BusLocationData? Destination      { get; set; }
    public string JourneyDate     { get; set; } = "";
}