# 📚 BookLibraryAPI

A clean, structured **RESTful Web API** built with **ASP.NET Core**, designed to manage a collection of books.  
This project demonstrates proper layering, DTO usage, validation, and centralized exception handling — making it a great foundation for learning or extending into a more advanced system.

---

## 🚀 What is this project?

BookLibraryAPI provides full **Create, Read, Update, Delete (CRUD)** capability for book records.  
It uses **Entity Framework Core with SQL Server**, along with a clean, maintainable architecture.

### ✔ Features

- Full CRUD API for managing books  
- DTOs for input/output separation  
- Centralized error handling using custom middleware  
- Automatic model validation via `[ApiController]`  
- Repository + Service layers for clean separation of concerns  
- EF Core integration with SQL Server  
- Fully dependency-injected architecture  

---

## 🏗 Architecture Overview

The project follows a layered design inspired by Clean Architecture:

### 📚 Layers

| Layer | Responsibility | Examples |
|-------|----------------|----------|
| **API / Controller Layer** | Handles HTTP routing & responses | `Controllers/BookController.cs` |
| **Service Layer** | Business logic, validation, coordination | `Services/IBookService.cs`, `Services/BookService.cs` |
| **Repository Layer** | Database access using EF Core | `Repositories/IBookRepository.cs`, `Repositories/BookRepository.cs` |
| **Domain / Entities** | Core models stored in the database | `Models/Book.cs` |
| **Middleware** | Global exception handling | `Middleware/ExceptionHandlingMiddleware.cs` |

### 🔍 Why this structure?

- Controllers stay thin  
- Business logic is centralized in the service layer  
- Repository abstracts EF Core data access  
- Middleware ensures consistent `ProblemDetails` errors  
- Codebase remains clean, maintainable, and easy to extend  

---

## 📦 Technologies Used

- ASP.NET Core 8  
- Entity Framework Core (SQL Server)  
- Dependency Injection  
- ProblemDetails for error responses  
- Model validation (Data Annotations)  
- Custom exception-handling middleware
