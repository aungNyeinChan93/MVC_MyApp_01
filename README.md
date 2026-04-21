# MVC_MyApp_01

Simple ASP.NET Core MVC sample application (Razor Views) demonstrating basic CRUD for `Item` and `Category` entities.

## Project details
- Framework: .NET 10
- Language: C# 14
- Project type: ASP.NET Core MVC (Razor views)
- Solution root: repository contains the `mvc_02` project

## Features
- List, view details, create, edit and delete `Item` entries.
- `Category` lookup used when creating/editing items.
- EF Core used for persistence; migrations are included (`Migrations/20260421122455_initial.cs`).
- Layered services: `ItemService`, `CategoryService` handle business/data access logic.

## Important files
- `mvc_02/Program.cs` - application startup and configuration
- `mvc_02/Data/AppDbContext.cs` - EF Core DbContext
- `mvc_02/Models/Item.cs`, `mvc_02/Models/Category.cs` - domain models
- `mvc_02/Services/ItemService.cs`, `mvc_02/Services/CategoryService.cs` - service layer
- `mvc_02/Controllers/ItemsController.cs` - controller exposing CRUD endpoints for items
- `mvc_02/Views/Items/` - Razor views for list, detail, create, edit
- `mvc_02/appsettings.json` - configuration, including the connection string

## Routes (ItemsController)
- GET `/Items` -> list all items
- GET `/Items/Detail/{id}` -> view item detail
- GET `/Items/Create` -> show create form (passes categories)
- POST `/Items/Save` -> create item
- GET `/Items/Edit/{id}` -> show edit form (passes categories)
- POST `/Items/Update/{id}` -> update item
- POST `/Items/Delete/{id}` -> delete item

## Prerequisites
- .NET 10 SDK installed
- (Optional) Visual Studio 2022/2026 or VS Code
- If using EF Core tools: `dotnet tool install --global dotnet-ef` or ensure `dotnet-ef` available

## Setup and run (CLI)
1. Restore and build:
   - `dotnet restore mvc_02`
   - `dotnet build mvc_02`
2. Apply database migrations (uses connection string in `mvc_02/appsettings.json`):
   - `cd mvc_02`
   - `dotnet ef database update`
3. Run the app:
   - `dotnet run --project mvc_02`

## Run in Visual Studio
- Open the solution in Visual Studio, set the `mvc_02` project as startup project and run (F5).

## Notes and troubleshooting
- Ensure the connection string in `mvc_02/appsettings.json` points to a reachable database. The included migration creates the required schema.
- If views fail to render, confirm the Views exist under `mvc_02/Views/Items` and controller action names match view file names (the project uses explicit view names in some actions).

## Contributing
- Open an issue or submit a PR. Keep changes small and focused; update or add migrations when modifying the EF model.

