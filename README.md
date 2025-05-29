![mainImage](https://github.com/user-attachments/assets/a44a0c15-bfff-4d72-b5a3-f7333494a32b)

<div align="center">
   <strong>A code first MVC + CQRS application</strong>
   <strong><br>With enhance visuals with Bootstrap and KendoUI</strong>
</div>


# News Management System

## 📜 Overview

The **News Management System** is a robust ASP.NET Core MVC application designed to manage news articles and categories efficiently. It incorporates modern best practices like many-to-many relationships, client-server-side validation, AJAX functionality for bulk actions, and user-friendly error handling. Additionally, the project leverages the **CQRS pattern** for improved maintainability and scalability.

---

## ✨ Features

- **A sample news management project** that uses the **MVC architecture enhanced with CQRS** for better maintainability.
- CRUD pages for managing **news** and **categories**.
- Many-to-many relationship between news and categories.
- **SQLite** as the database for simplicity and portability.
- **Unique constraint** on category name with proper error handling.
- Ability to delete multiple news items at once using **AJAX**.
- Comprehensive **validation** for every field.
- **Automatic database migration** applied at app startup.
- Code-first implementation of the database schema.
- Enhanced visuals with **Bootstrap** and **Kendo UI**.

---

## 🛠️ Technical Details

### ⚙️ Technology Stack
- **Backend Framework:** ASP.NET Core 9.0
- **Database:** SQLite with **Entity Framework Core** ORM
- **Frontend Framework:** Razor Pages with **Bootstrap** and **Kendo UI**
- **AJAX Integration:** Fetch API for dynamic interactions

---

## 📂 Project Structure

```
NewsApp/
│
├── NewsApp.csproj               // Project file
├── appsettings.json             // Application configuration
├── appsettings.Development.json // Development-specific configuration
├── Dockerfile                   // Docker configuration
│
├── Application/                 // Application layer for CQRS
│   ├── Commands/                // Command-related logic
│   │   ├── Category/
│   │   │   ├── CreateCategoryCommand.cs
│   │   │   ├── CreateCategoryCommandHandler.cs
│   │   │   ├── DeleteCategoryCommand.cs
│   │   │   ├── DeleteCategoryCommandHandler.cs
│   │   │   ├── EditCategoryCommand.cs
│   │   │   ├── EditCategoryCommandHandler.cs
│   │   └── NewsCommands/
│   │       ├── CreateNewsCommand.cs
│   │       ├── CreateNewsCommandHandler.cs
│   │       ├── DeleteNewsCommand.cs
│   │       ├── DeleteNewsCommandHandler.cs
│   │       ├── DeleteMultipleNewsCommand.cs
│   │       ├── DeleteMultipleNewsCommandHandler.cs
│   │       ├── EditNewsCommand.cs
│   │       └── EditNewsCommandHandler.cs
│
│   ├── Queries/                 // Query-related logic
│   │   ├── CategoryQueries/
│   │   │   ├── GetCategoriesQuery.cs
│   │   │   ├── GetCategoriesQueryHandler.cs
│   │   │   ├── GetCategoryQuery.cs
│   │   │   ├── GetCategoryQueryHandler.cs
│   │   │   ├── CategoryNameQuery.cs
│   │   │   ├── CategoryNameQueryHandler.cs
│   │   └── NewsQueries/
│   │       ├── GetAllNewsCommand.cs
│   │       ├── GetAllNewsCommandHandler.cs
│   │       ├── GetSingleNewsQuery.cs
│   │       └── GetSingleNewsQueryHandler.cs
│   │
│   └── Interfaces/              // Repository interfaces
│       ├── ICategoryRepository.cs
│       └── INewsRepository.cs
│
├── Infrastructure/              // Infrastructure layer
│   ├── Data/
│   │   ├── DataContext.cs       // EF Core DbContext
│   └── Repository/
│       ├── CategoryRepository.cs
│       └── NewsRepository.cs
│
├── Controllers/
│   ├── NewsController.cs        // Handles news-related actions
│   └── CategoryController.cs    // Handles category-related actions
│
├── Models/
│   ├── News.cs                  // News entity
│   ├── Category.cs              // Category entity
│   └── ErrorViewModel.cs        // Error model for shared views
│
├── Migrations/                  // EF Core migrations
│   ├── 20250111185329_Initial.cs
│   ├── 20250117124153_UniqueConstraintForCategoryName.cs
│   └── DataContextModelSnapshot.cs
│
├── Views/
│   ├── News/
│   │   ├── Index.cshtml         // News list
│   │   ├── Create.cshtml        // Create news
│   │   ├── Edit.cshtml          // Edit news
│   │   ├── Details.cshtml       // News details
│   ├── Category/
│   │   ├── Index.cshtml         // Category list
│   │   ├── Create.cshtml        // Create category
│   │   ├── Edit.cshtml          // Edit category
│   │   └── Details.cshtml       // Category details
├── wwwroot/
│   ├── js/
│   │   └── NewsIndex.js         // AJAX multiple news delete logic
└── Program.cs                   // App entry point
```

---

## 🚀 Getting Started

### 📦 Prerequisites
- **.NET SDK 9.0 or higher**: [Download .NET](https://dotnet.microsoft.com/download)

### 🖥️ Installation

1. **Clone the Repository:**
   ```bash
   git clone https://github.com/wardaddyov/MVC-CQRS-Newsapp.git
   cd MVC-CQRS-Newsapp
   ```

2. **Install Dependencies:**
   Ensure you have the required NuGet packages installed:
   ```bash
   dotnet restore
   ```

3. **Setup Database:**
   The project uses SQLite. The database file will be automatically created and updated at runtime.

4. **Run the Application:**
   ```bash
   dotnet run
   ```

5. **Access the Application:**
   Open your browser and navigate to `https://localhost:5171`.

---

## ✨ Highlights of the AJAX Bulk Deletion Featur

### 🛠️ JavaScript File (`newsIndex.js`):
- **Select All/None Functionality:** Allows users to select multiple news items at once.
- **AJAX Integration:** Sends an asynchronous POST request to delete selected items.
- **Real-Time UI Updates:** Removes deleted rows from the table dynamically.

## 🛡️ Security

This project follows **ASP.NET Core security best practices**, including:
- **CSRF Protection:** Anti-forgery tokens are implemented for all forms.
- **Input Validation:** Models are validated both on the server and optionally on the client.
- **Error Handling:** Clear error messages are provided for user actions, such as duplicate category creation.

---

## 📚 Additional Resources

- [ASP.NET Core Documentation](https://docs.microsoft.com/en-us/aspnet/core/)
- [Entity Framework Core Documentation](https://docs.microsoft.com/en-us/ef/core/)
- [Bootstrap Documentation](https://getbootstrap.com/docs/5.3/getting-started/introduction/)

---

## 👨‍💻 Author

**Amir Mirzababapour Sangrudi**  
[GitHub Profile](https://github.com/wardaddyov)  
[LinkedIn Profile](https://www.linkedin.com/in/amir-mirzababapour-sangrudi-46886b242/)


