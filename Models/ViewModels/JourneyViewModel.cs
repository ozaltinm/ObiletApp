// Models/ViewModels/JourneyViewModel.cs
using System;

namespace ObiletApp.Models.ViewModels
{
    public class JourneyViewModel
    {
        public long   Id                { get; set; }
        public string? Departure       { get; set; }
        public string? Arrival         { get; set; }
        public string? InternetPrice    { get; set; }
        public string OriginLocation    { get; set; } = "";
        public string DestinationLocation { get; set; } = "";
    }
}
