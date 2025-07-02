ObiletApp

An ASP.NET Core MVC application for searching and displaying bus journeys via the Obilet API.

📝 Table of Contents

Features

Tech Stack

Prerequisites

Getting Started

Clone Repository

Configure Settings

Restore & Build

Run

Project Structure

Key Functionality

Validation & UX

Future Improvements

License

🔥 Features

Fetches origin & destination locations from Obilet API

Lets users pick origin, destination & date (today/tomorrow shortcuts)

Validates that origin ≠ destination & date ≥ today

Displays journey results in a card layout with departure/arrival times, price & stops

Swap button to exchange origin/destination selections

🛠 Tech Stack

Backend: ASP.NET Core MVC (.NET 7+)

Views: Razor Pages with Bootstrap 5

HTTP Client: HttpClient with System.Text.Json

Validation: DataAnnotations + jQuery Validate (Unobtrusive)

Caching: IMemoryCache

Version Control: Git

📦 Prerequisites

.NET 7 SDK or higher

Visual Studio 2022 / VS Code

🚀 Getting Started

Clone Repository

git clone https://github.com/your-org/ObiletApp.git
cd ObiletApp

Configure Settings

In appsettings.Development.json, add your Obilet API base URL and credentials:

{
  "ObiletApi": {
    "BaseUrl": "https://api.obilet.com",
    "ApiKey": "YOUR_API_KEY_HERE"
  }
}

(use user secrets or environment variables for production)

Restore & Build

dotnet restore
dotnet build

Run

dotnet run

Browse to https://localhost:5001 to access the app.

📁 Project Structure

/ObiletApp
├── Controllers
│   └── HomeController.cs      # Search form & results logic
├── Models
│   ├── Dtos                   # API request/response DTOs
│   └── ViewModels             # SearchViewModel, JourneySearchResultViewModel
├── Services
│   └── ObiletApiService.cs    # Wraps HTTP calls to Obilet
├── Helpers
│   └── JsonConverters         # Custom JSON converters
├── Views
│   ├── Home
│   │   ├── Index.cshtml       # Search form
│   │   └── Results.cshtml     # Journey results page
│   └── Shared
│       └── _Layout.cshtml     # Main layout
└── wwwroot                    # Static assets

⭐ Key Functionality

Session & Locations

On GET /Home/Index, fetches session/device IDs then calls GetBusLocations() to populate dropdowns.

Search POST

Validates origin ≠ destination & date ≥ today.

Calls GetJourneys() and maps to JourneyViewModel (formats times and price).

Results Display

Card-based list showing departure & arrival, price badge, and route footer.

Swap Button

Swaps dropdown values client-side with JavaScript.

✔ Validation & UX

Server-side:

DataAnnotations ([Required], custom ModelState.AddModelError)

Repopulates dropdowns on error.

Client-side:

HTML5 date min attribute to prevent past dates.

Unobtrusive jQuery Validate.

Quick date selectors (today/tomorrow).

🚧 Future Improvements

Pagination & filtering of results

Distributed caching (e.g., Redis) for location lists

Unit & integration tests for controllers and services

Resilient HTTP (Polly) and global error handling

Accessibility enhancements (ARIA labels)

📄 License

This project is licensed under the MIT License. See LICENSE for details.

