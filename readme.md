
# ObiletApp

> **Bus Journey Search Application** using the Obilet API, built with ASP.NET Core MVC and Bootstrap 5.

---

## 📝 Table of Contents

1. [🚀 Features](#🚀-features)
2. [🛠 Tech Stack](#🛠-tech-stack)
3. [📦 Prerequisites](#📦-prerequisites)
4. [🚀 Getting Started](#🚀-getting-started)
   - [1. Clone](#1-clone)
   - [2. Configuration](#2-configuration)
   - [3. Build](#3-build)
   - [4. Run](#4-run)
5. [📂 Project Structure](#📂-project-structure)
6. [⚙️ Key Functionality](#⚙️-key-functionality)
7. [✔️ Validation & UX](#✔️-validation--ux)
8. [🚧 Future Improvements](#🚧-future-improvements)
9. [📄 License](#📄-license)

---

## 🚀 Features

- 🎯 **Search form** with origin, destination, and date (with “Today”/“Tomorrow” shortcuts)
- 🔀 **Swap** origin/destination selections on-the-fly
- 📋 **Validations**: origin ≠ destination, date ≥ today
- 🚌 **Results page**: card layout displaying departure/arrival times, price, and stops
- 🌐 **API integration**: Fetches session & locations, then journeys via Obilet endpoints

## 🛠 Tech Stack

| Layer       | Technology                       |
| ----------- | -------------------------------- |
| Backend     | ASP.NET Core MVC (.NET 7+)       |
| Frontend    | Razor Views, Bootstrap 5         |
| HTTP Client | `HttpClient`, `System.Text.Json` |
| Validation  | DataAnnotations, jQuery Validate |
| Caching     | `IMemoryCache`                   |
| Versioning  | Git, GitHub                      |

## 📦 Prerequisites

- .NET 7 SDK or higher
- Visual Studio 2022 / VS Code
- (Optional) Node.js & npm for client-side tooling

---

## 🚀 Getting Started

### 1. Clone

```bash
git clone https://github.com/your-org/ObiletApp.git
cd ObiletApp
```

### 2. Configuration

Add Obilet API settings in `appsettings.Development.json`:

```jsonc
{
  "ObiletApi": {
    "BaseUrl": "https://api.obilet.com",
    "ApiKey": "<YOUR_API_KEY>"
  }
}
```

> **Tip:** Use Secret Manager or environment variables for sensitive data.

### 3. Build

```bash
dotnet restore
dotnet build --configuration Debug
```

### 4. Run

```bash
dotnet run
```

Open your browser at `https://localhost:5001`.

---

## 📂 Project Structure

```
ObiletApp/
├─ Controllers/
│   └─ HomeController.cs       # Handles form & results
├─ Models/
│   ├─ Dtos/                   # API request/response models
│   └─ ViewModels/             # Search & result view models
├─ Services/
│   └─ ObiletApiService.cs     # Encapsulates HTTP calls
├─ Helpers/
│   └─ JsonConverters/         # Custom JSON converters
├─ Views/
│   ├─ Home/
│   │   ├─ Index.cshtml        # Search page
│   │   └─ Results.cshtml      # Results page
│   └─ Shared/_Layout.cshtml   # Site layout
└─ wwwroot/                    # CSS, JS, images
```

---

## ⚙️ Key Functionality

1. **Session & Location Fetch**: on GET `/Home/Index`, obtains session/device IDs and loads dropdowns.
2. **Form Validation**: ensures origin/destination differ and date isn’t in the past.
3. **Journey Retrieval**: builds `JourneyRequestDTO`, calls API, maps to `JourneyViewModel` (formats times & price).
4. **Results Display**: Bootstrap cards showing times, price badge, and route footer.
5. **Swap Button**: client-side JS to swap dropdown values instantly.

---

## ✔️ Validation & UX

- **Server-side**: DataAnnotations (`[Required]`), `ModelState.AddModelError`, repopulate dropdowns on error.
- **Client-side**: HTML5 date `min` attribute, jQuery Validate (Unobtrusive), clear-on-change disabled by default.
- **UX**: quick-select “Today” and “Tomorrow” buttons.

---

## 🚧 Future Improvements

- 🔄 **Pagination & Filtering** of search results
- ⚡ **Distributed Caching** (Redis) for location data
- ✅ **Automated Tests**: unit & integration tests
- 🏗️ **Resilience**: Polly policies for retries/circuit-breaker
- ♿ **Accessibility**: ARIA labels, keyboard navigation

---

## 📄 License

This project is licensed under the **MIT License**. See [LICENSE](LICENSE) for details.

