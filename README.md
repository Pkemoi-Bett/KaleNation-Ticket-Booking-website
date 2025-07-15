
# KaleNation Ticket Booking

**KaleNation Ticket Booking** is a .NET-based web application developed to streamline the process of exploring, booking, and managing event tickets. Built with Clean Architecture principles, it reflects a maintainable, scalable, and testable codebase structure—drawing on the creator's experience in crafting robust .NET solutions like MessageSenderApi.

## Tech Stack

- ASP.NET Core (.NET 8)
- Entity Framework Core
- SQL Server
- Razor Pages / Blazor / MVC (based on implementation)
- Clean Architecture Pattern
- Dependency Injection
- Serilog / Custom Logging
- xUnit / Integration Testing

## 🚀 Features

- 🎟️ Event listing with search and filters
- 🔐 User registration and secure authentication (JWT)
- 💳 Booking workflow with payment integration
- 🛠️ Admin dashboard for event & ticket management
- 📅 Real-time seat tracking and booking availability

## 🏗️ Architecture

Follows Clean Architecture, with distinct layers:

| Layer            | Responsibility                             |
|------------------|---------------------------------------------|
| Presentation     | Razor Pages / Blazor frontend UI            |
| Application      | Business logic, use cases                   |
| Domain           | Core models and rules                       |
| Infrastructure   | Data access, external services (e.g., SMS)  |

## 📦 Setup Instructions

1. Clone the repo  

2. Configure the connection string in `appsettings.Development.json`

3. Apply migrations  
   ```bash
   dotnet ef database update
   ```

4. Run the application  
   ```bash
   dotnet run
   ```

## 🧪 Testing

Includes unit and integration tests with xUnit. Run all tests:

```bash
dotnet test
```

## 🤝 Contributing

Pull requests are welcome! If you spot bugs or have ideas for features, feel free to open issues.

