# VendorHub API

RESTful backend API for managing vendors and their products, built with ASP.NET Core and PostgreSQL.
## Documentation
(https://vendor-hub-api.onrender.com/swagger/index.html) [Swagger Documentation]
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


```mermaid
flowchart TD
    Client --> Controllers
    Controllers --> Services
    Services --> Repositories

erDiagram
    VENDOR ||--o{ PRODUCT : has

    VENDOR {
        uuid Id PK
        string Name
        string Email
        int NumberOfProducts
        boolean IsApproved
    }

    PRODUCT {
        uuid Id PK
        string Name
        decimal Price
        uuid VendorId FK
    }
    Repositories --> EF[Entity Framework Core]
    EF --> PostgreSQL
