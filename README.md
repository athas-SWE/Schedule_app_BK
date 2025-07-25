# Appointment Scheduler - Backend (ASP.NET Core 8 Web API)

## 🛠️ Features

- RESTful API for Appointment and Slot management
- Admin login (optional dummy login)
- SQL Server support (Entity Framework Core)
- CORS enabled for frontend interaction
- Unit testing via xUnit


## 🚀 Getting Started

### 1. Prerequisites

- [.NET 8 SDK]
- SQL Server (local or cloud)

### 2. Database Configuration

Update `appsettings.json` with your SQL Server connection string:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=ScheduleDb;Trusted_Connection=True;"
}

cd Api
dotnet ef migrations add InitialCreate
dotnet ef database update


dotnet run



POST /api/auth/login
{
  "username": "admin",
  "password": "admin123"
}



