using System.Collections.Generic;

namespace ObiletApp.Models.ViewModels;

public class JourneySearchResultViewModel
{
    public List<JourneyViewModel> Journeys { get; set; } = new();
    public int? OriginId           { get; set; }
    public int? DestinationId      { get; set; }
    public string JourneyDate     { get; set; } = "";
}