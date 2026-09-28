# FinLedger

FinLedger is a small personal finance API built with ASP.NET Core.

I built this project mainly to practice **Clean Architecture**, **EF Core**, and building a simple REST API with .NET.

## What it does

FinLedger lets users:

* Create users
* Create financial accounts
* Add income
* Add expenses
* Track account balances
* View accounts
* View transactions

## Tech Stack

* ASP.NET Core
* C#
* Entity Framework Core
* PostgreSQL
* Neon
* Swagger
* xUnit

## Architecture

The project follows a simple Clean Architecture structure:

```text
FinLedger
├── FinLedger.Api
├── FinLedger.Application
├── FinLedger.Domain
└── FinLedger.Infrastructure
```

The dependency flow is:

```text
API → Application → Domain
          ↑
     Infrastructure
```

### Domain

Contains the core business logic and entities.

```text
User
Account
Transaction
```

For example, account balance changes are handled by the domain:

```csharp
account.AddMoney(amount);
account.RemoveMoney(amount);
```

### Application

Contains the application logic, DTOs, services, and repository interfaces.

### Infrastructure

Contains the database-related code:

* EF Core
* PostgreSQL
* DbContext
* Entity configurations
* Repository implementations

### API

Contains the controllers, middleware, Swagger configuration, and dependency injection setup.

## Main Endpoints

### Users

```http
POST /api/users
```

### Accounts

```http
POST /api/accounts
GET /api/accounts?userId={userId}
```

### Transactions

```http
POST /api/transactions/income
POST /api/transactions/expense
GET /api/transactions?accountId={accountId}
```

## Running Locally

Clone the repository and restore the packages:

```bash
dotnet restore
```

The project uses an ASP.NET Core connection string named:

```text
ConnectionStrings:DefaultConnection
```

For local development, I use **User Secrets** instead of putting the database password in `appsettings.json`.

Set it with:

```bash
dotnet user-secrets set "ConnectionStrings:DefaultConnection" "YOUR_CONNECTION_STRING" --project FinLedger.Api
```

Run the API:

```bash
dotnet run --project FinLedger.Api
```

Then open Swagger:

```text
http://localhost:YOUR_PORT/swagger
```

## Database

FinLedger uses PostgreSQL with Entity Framework Core migrations.

To update the database:

```bash
dotnet ef database update \
  --project FinLedger.Infrastructure \
  --startup-project FinLedger.Api
```

## Tests

The domain business rules have unit tests using xUnit.

Run:

```bash
dotnet test
```

## Why I built this

This isn't meant to be a production banking system.

The goal was to build a small project that helped me understand how a Clean Architecture application is structured in ASP.NET Core and how the different layers communicate with each other.

Some of the things I practiced while building it:

* Clean Architecture
* Dependency Injection
* Repository pattern
* EF Core
* PostgreSQL
* Database migrations
* Domain business rules
* API validation
* Exception handling
* Unit testing
* Swagger
