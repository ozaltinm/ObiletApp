using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using ObiletApp.Models.Dtos.Shared;

namespace ObiletApp.Models.ViewModels;

public class SearchViewModel
{
      public int? SelectedOriginId { get; set; }
    public int? SelectedDestinationId { get; set; }

    public List<BusLocationData> Origins      { get; set; } = new();
    public List<BusLocationData> Destinations { get; set; } = new();
    public string JourneyDate                { get; set; } = string.Empty;

    public IEnumerable<SelectListItem> OriginItems      { get; set; } = Enumerable.Empty<SelectListItem>();
    public IEnumerable<SelectListItem> DestinationItems { get; set; } = Enumerable.Empty<SelectListItem>();
    
}
