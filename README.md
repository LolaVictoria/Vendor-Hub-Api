# VendorHub API

RESTful backend API for managing vendors and their products, built with ASP.NET Core and PostgreSQL.

## Features

- Vendor CRUD operations
- Product CRUD operations
- Vendor-product relationships
- Request validation
- Global exception handling
- Swagger API documentation
- Unit testing

## Tech Stack

| Technology | Purpose |
|---|---|
| C# / .NET 10 | Backend |
| ASP.NET Core | REST API |
| Entity Framework Core | ORM and database migrations |
| PostgreSQL | Database |
| Npgsql | PostgreSQL provider |
| Swagger / OpenAPI | API documentation |
| xUnit / Moq | Unit testing |

## Architecture

```mermaid
flowchart TD
    Client --> Controllers
    Controllers --> Services
    Services --> Repositories
    Repositories --> EF[Entity Framework Core]
    EF --> PostgreSQL
