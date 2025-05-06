# DocumentMe.API

A simple .NET 8 Web API project that demonstrates how to use **Swagger / OpenAPI** via **Swashbuckle** to generate interactive and annotated API documentation.

## 🌦 Purpose

The main goal of this project is to illustrate how to:

- Generate Swagger documentation using Swashbuckle in ASP.NET Core 8.
- Annotate controllers, models, and endpoints using XML comments and operation filters.
- Use mock repositories for demonstration purposes.
- Export Swagger documentation to `swagger.json` file (and optionally XML).
- Simulate a real-world use case with a **WeatherForecast API**.

---

## 📁 Project Structure

```
D:.
│   Program.cs                 # App entry point with Swagger setup
│   swagger.json              # Exported Swagger documentation
│   DocumentMe.API.csproj     # Project file
│
├───Controllers
│       WeatherForecastController.cs    # Sample API with documented endpoints
│
├───Data
│   │   WeatherForecastMockRepository.cs     # Mock data for testing
│   └───Abstraction
│           IRepository.cs                  # Simple repository abstraction
│
├───Models
│       WeatherForecast.cs                  # Data model
│
├───Swagger
│   │   ServiceCollectionExtension.cs       # Swagger service setup
│   │   ServiceProviderExtension.cs         # Swagger export helper
│   ├───Filters
│   │       AddRequiredHeaderParameterOperationFilter.cs
│   │       CreatedResponseLinkOperationFilter.cs
│   │       WeatherDescriptionOperationFilter.cs
│   └───Providers
│           WeatherForecastExampleProvider.cs  # Example response provider
```

---

## 🚀 How to Run

1. Clone or download the repository.
2. Open in Visual Studio or run from CLI.
3. Ensure XML documentation is enabled in `csproj`:
   ```xml
   <GenerateDocumentationFile>true</GenerateDocumentationFile>
   ```
4. Build and run the project:
   ```bash
   dotnet run
   ```

5. Access Swagger UI at:
   ```
   https://localhost:{port}/swagger
   ```

6. Swagger documentation will also be written to `swagger.json` during development startup.

---

## 🔍 Features Demonstrated

- ✅ **Swagger/OpenAPI integration** via `Swashbuckle.AspNetCore`
- ✅ **XML comments** on models and controllers
- ✅ **Operation filters** to customize documentation:
  - Required headers
  - Example responses
  - Hypermedia links
- ✅ **Mock repository** (`WeatherForecastMockRepository`) to simulate data source
- ✅ **Custom example provider** for enhanced Swagger display

---

## 🧪 Example Endpoint

```http
GET /weatherforecast
```

**Response:**

```json
[
  {
    "date": "2025-05-06",
    "temperatureC": 100,
    "summary": "string"
  }
]
```

Use the Swagger UI to test the endpoint interactively and see headers, links, and examples included via filters.

---

## 📄 License

Licensed under the [MIT License](https://opensource.org/licenses/MIT).

---


