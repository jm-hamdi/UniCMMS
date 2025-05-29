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

## Fonctionnalités principales

* **CRUD complet** pour les entités `WorkOrder` et `User`
* **Filtres dynamiques** sur la liste des WorkOrders (filtrage par statut et utilisateurs assignés)
* **Pagination** sur les listes pour gérer efficacement les grandes données
* **Architecture en couches** (API, Application, Domain, Infrastructure)
* **Gestion centralisée des erreurs** via middleware
* **Mapping propre des entités vers DTOs** grâce à Mapster
* **Logs structurés** avec Serilog, configurés par environnement
* **Documentation interactive** via Swagger UI

---


##  Setup Instructions

```bash
dotnet restore
dotnet ef database update --project UniCMMS.Infrastructure --startup-project UniCMMS.API
dotnet run --project UniCMMS.API
```

---

## Exemple d’appel API

Récupérer les WorkOrders paginés et filtrés :

```
GET /api/workorders?status=Open&assigneeId=2&pageNumber=1&pageSize=10
```

Réponse JSON avec totalCount et items.

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