# BookStore API

This project is a simple REST API for managing a book store, built using C# and ASP.NET Core. It allows you to perform CRUD operations on books in a PostgreSQL database.

## Features

- **Get all books**: Retrieve a list of all books in the store.
- **Get a book by ID**: Retrieve details of a specific book by its ID.
- **Add a new book**: Add a new book to the store.
- **Update a book**: Update details of an existing book.
- **Delete a book**: Remove a book from the store.
- **Soft delete a book**: Mark a book as deleted without removing it from the database.

## Prerequisites

- [.NET 7 SDK](https://dotnet.microsoft.com/download/dotnet/7.0)
- [PostgreSQL](https://www.postgresql.org/download/)

## Getting Started

### Configuration
Update the appsettings.json file with your PostgreSQL connection details:

json
```{
  "ConnectionStrings": {
    "BookDbConnection": "Server=localhost;Database=BookStore;Port=5432;User Id=postgres;Password=postgres;"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
```
### Database Setup
Ensure your PostgreSQL server is running, then create the database and apply migrations:

```dotnet ef database update```

### Run the Application
```dotnet run```

### Swagger UI
You can explore and test the API endpoints using Swagger UI. Once the application is running, navigate to https://localhost:7118/swagger/index.html.

### View Datbase changes
Preferred Method: Use pgAdmin4 to view BookStore Database.

## API Endpoints
- GET /api/book/getall - Get all books.g
- GET /api/book/getbyid/{id} - Get a book by ID.
- POST /api/book/add - Add a new book.
- PUT /api/book/update - Update an existing book.
- PUT /api/book/updateisdeleted - Soft delete a book.
- DELETE /api/book/delete/{id} - Delete a book.

## Project Structure
- Controllers/BookController.cs - Contains the API endpoints.
- Data/BookDbContext.cs - Database context for Entity Framework Core.
- Models/Book.cs - Book model with data annotations for validation.
- Program.cs - Configures the application and services.

## Dependencies
- ASP.NET Core
- Entity Framework Core
- Npgsql (PostgreSQL driver for .NET)
- Swagger (Swashbuckle)
