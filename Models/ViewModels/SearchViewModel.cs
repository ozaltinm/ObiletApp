using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using ObiletApp.Models.Dtos.Shared;

namespace ObiletApp.Models.ViewModels;

public class SearchViewModel
{
    [Required(ErrorMessage = "Lütfen kalkış noktasını seçin.")]
    public BusLocationData? SelectedOrigin { get; set; }
    
    [Required(ErrorMessage = "Lütfen varış noktasını seçin.")]
    public BusLocationData? SelectedDestination { get; set; }

    public List<BusLocationData> Origins      { get; set; } = new();
    public List<BusLocationData> Destinations { get; set; } = new();

    [Required(ErrorMessage = "Lütfen tarih girin.")]
    public string JourneyDate { get; set; } = string.Empty;

    public IEnumerable<SelectListItem> OriginItems      { get; set; } = Enumerable.Empty<SelectListItem>();
    public IEnumerable<SelectListItem> DestinationItems { get; set; } = Enumerable.Empty<SelectListItem>();
    
}
