// Models/ViewModels/JourneyViewModel.cs
using System;

namespace ObiletApp.Models.ViewModels
{
    public class JourneyViewModel
    {
        public long   Id                { get; set; }
        public string PartnerName       { get; set; } = "";
        public string BusType           { get; set; } = "";
        public DateTime Departure       { get; set; }
        public DateTime Arrival         { get; set; }
        public decimal InternetPrice    { get; set; }
        public string OriginLocation    { get; set; } = "";
        public string DestinationLocation { get; set; } = "";
    }
}
