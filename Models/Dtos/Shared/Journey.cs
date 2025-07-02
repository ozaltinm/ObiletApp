using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using ObiletApp.Converters;

namespace ObiletApp.Models.Dtos.Shared
{
    public class Journey
    {
        [JsonPropertyName("kind")]
        public string? Kind { get; set; }

        [JsonPropertyName("code")]
        public string? Code { get; set; }

        [JsonPropertyName("stops")]
        public List<JourneyStop>? Stops { get; set; }

        [JsonPropertyName("origin")]
        public string? Origin { get; set; }

        [JsonPropertyName("destination")]
        public string? Destination { get; set; }

        [JsonPropertyName("departure")]
        public DateTime Departure { get; set; }

        [JsonPropertyName("arrival")]
        public DateTime Arrival { get; set; }

        [JsonPropertyName("currency")]
        public string? Currency { get; set; }

        [JsonPropertyName("duration")]
        public string? Duration { get; set; }

        [JsonPropertyName("duration-offset")]
        public string? DurationOffset { get; set; }

        [JsonPropertyName("original-price")]
        public decimal OriginalPrice { get; set; }

        [JsonPropertyName("internet-price")]
        
        [JsonConverter(typeof(PriceToStringConverter))]
        public string? InternetPrice { get; set; }

        [JsonPropertyName("booking")]
        public object? Booking { get; set; }

        [JsonPropertyName("available")]
        public object? Available { get; set; }

        [JsonPropertyName("bus-name")]
        public string? BusName { get; set; }

        [JsonPropertyName("description")]
        public object? Description { get; set; }

        [JsonPropertyName("features")]
        public List<string>? Features { get; set; }

        [JsonPropertyName("features-description")]
        public object? FeaturesDescription { get; set; }

        [JsonPropertyName("has-available-seat-info")]
        public bool HasAvailableSeatInfo { get; set; }

        [JsonPropertyName("has-multiple-brandedfare-selection")]
        public bool HasMultipleBrandedFareSelection { get; set; }

        [JsonPropertyName("is-segmented")]
        public bool IsSegmented { get; set; }

        [JsonPropertyName("partner-name")]
        public string? PartnerName { get; set; }

        [JsonPropertyName("partner-provider-code")]
        public string? PartnerProviderCode { get; set; }

        [JsonPropertyName("partner-provider-id")]
        public int? PartnerProviderId { get; set; }

        [JsonPropertyName("peron-no")]
        public string? PeronNo { get; set; }

        [JsonPropertyName("policy")]
        public JourneyPolicy? Policy { get; set; }

        [JsonPropertyName("provider-code")]
        public string? ProviderCode { get; set; }

        [JsonPropertyName("provider-internet-price")]
        public decimal? ProviderInternetPrice { get; set; }

        [JsonPropertyName("sorting-price")]
        public decimal SortingPrice { get; set; }
    }
}
