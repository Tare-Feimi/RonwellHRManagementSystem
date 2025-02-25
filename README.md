Ronwell HR Management System
A multi-module HR Management System built using ASP.NET Core MVC, Entity Framework Core, MediatR, and AutoMapper. This solution demonstrates a layered architecture, separation of concerns, dependency injection, and unit testing for handling employee data, administration, project management, training management, and HR reports.

Overview
The Ronwell HR Management System provides the following modules:

Employee Management: Manage employee details including personal information, skills, and experience.
Administration: Perform HR administration tasks such as hiring employees.
Project Management: Create and manage projects associated with employees.
Training Management: Schedule and manage training sessions for employees.
HR Reports: Generate summary reports of HR data (e.g., total employees, projects, and training sessions).
Technologies Used
.NET 6 / ASP.NET Core MVC
Entity Framework Core (with SQL Server)
MediatR (for CQRS pattern)
AutoMapper (for mapping between entities and DTOs)
xUnit, Moq, and FluentAssertions for unit testing
Git for version control
Project Structure
The solution is divided into several projects:

RonwellHR.Domain: Contains the core domain entities (e.g., Employee, Project, TrainingSession) and custom exceptions.
RonwellHR.Data: Contains the EF Core DbContext (HRDbContext) and repository implementations for data access.
RonwellHR.Application: Implements business logic with MediatR commands, queries, and AutoMapper profiles.
RonwellHR.Web: The ASP.NET Core MVC web application that includes controllers and Razor views.
RonwellHR.Tests: Unit tests for validating the application functionalities.
Setup Instructions
Prerequisites
.NET 6 SDK
SQL Server (or SQL Server Express / LocalDB)
Git
Clone the Repository
bash
Copy
git clone https://github.com/yourusername/RonwellHRManagementSystem.git
cd RonwellHRManagementSystem
Database Setup
Configure Connection String:
In the RonwellHR.Web/appsettings.json file, set your SQL Server connection string. For example:

json
Copy
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=RonwellHRDb;Trusted_Connection=True;MultipleActiveResultSets=true"
  }
}
Apply Migrations:
Open a terminal in the solution folder and run:

bash
Copy
dotnet ef migrations add InitialCreate --project RonwellHR.Data --startup-project RonwellHR.Web
dotnet ef database update --project RonwellHR.Data --startup-project RonwellHR.Web
These commands create the database schema based on the defined entities and migrations.

Running the Application
From the solution directory, run the following command:

bash
Copy
dotnet run --project RonwellHR.Web
Then, open your browser and navigate to https://localhost:5001 (or the port specified in your configuration). You should see the Home page with links to the different modules (Employee Management, Administration, Project Management, Training Management, HR Reports).

Usage
Home Page:
Provides navigation to all the modules.

Employee Module:
Manage employee details by creating, reading, updating, and deleting records.

Administration Module:
Use the hiring interface to mark employees as hired.

Project Module:
Create and list projects associated with employees.

Training Module:
Schedule and view training sessions.

HR Reports Module:
Generate a summary report of HR data.

Unit Testing
The solution includes unit tests using xUnit. To run the tests:

bash
Copy
dotnet test RonwellHR.Tests
Ensure that tests cover key functionalities such as employee creation, project assignments, training scheduling, and HR report generation.

Custom Error Handling
Custom exceptions (e.g., NotFoundException) are defined in the RonwellHR.Domain project and are used throughout the application for consistent error handling. Global exception handling middleware can be added to handle these exceptions uniformly.

Dependency Injection & Configuration
Dependency Injection:
All services (repositories, MediatR handlers, AutoMapper profiles, etc.) are registered in Program.cs using the built-in .NET Core DI container.

MediatR & AutoMapper:
These libraries are configured to automatically scan for handlers and mapping profiles across the solution.

Git Version Control
The repository is managed with Git. Commit changes regularly using descriptive messages.
Use feature branches for new functionality or bug fixes.
Share the repository link with your team or stakeholders as needed.
Additional Instructions
Documentation:
This README provides an overview and setup instructions. Additional documentation (e.g., API docs, design rationale) can be added as the project evolves.
Configuration Files:
Ensure that sensitive data like connection strings are secured using environment variables or user secrets for production deployments.
Extensibility:
The project is designed to be modular. You can add new modules or extend existing functionality by following the established patterns.
