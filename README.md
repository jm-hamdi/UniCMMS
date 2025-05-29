# UniCMMS
Développer une API RESTful en ASP.NET Core 8, utilisant Entity Framework Core avec SQL Server , pour gérer les ordres de travail (Work Orders) d’un système de gestion de maintenance (CMMS).



##  Description
RESTful API built with ASP.NET Core 8 and Entity Framework Core to manage work orders in a CMMS system.

---

##  Technologies

- ASP.NET Core 8
- Entity Framework Core
- SQL Server
- Clean Architecture
- Swagger (API Docs)

---

##  Features

- Work Order CRUD (with filters and pagination)
- User Management
- Status-based filtering
- Many-to-many assignment logic
- Error handling middleware
- Environment-based logging

---

##  Setup Instructions

```bash
dotnet restore
dotnet ef database update --project UniCMMS.Infrastructure --startup-project UniCMMS.API
dotnet run --project UniCMMS.API
```

---

##  Project Structure

- **API** – Controllers, Configurations, Middleware
- **Application** – Services, Interfaces, DTOs
- **Domain** – Entities, Interfaces
- **Infrastructure** – DbContext, Repository implementations

---

##  Authentication (To be implemented)

You can extend using JWT Authentication or ASP.NET Core Identity.

---

##  Testing the API

Access Swagger UI:
```
https://localhost:<port>/swagger
```