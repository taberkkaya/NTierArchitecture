<p align="center">
  <img src="icon.jpg" alt="NTierArchitecture Logo" width="200" />
</p>

<h1 align="center">NTierArchitecture</h1>

<p align="center">
  🧱 A clean and modular N-Tier architecture template built with .NET 8.
</p>

<p align="center">
  <img src="https://img.shields.io/badge/.NET-8.0-blue?logo=dotnet" />
  <img src="https://img.shields.io/badge/EF--Core-8.0-success?logo=entity-framework" />
  <img src="https://img.shields.io/badge/License-MIT-informational" />
</p>

---

## 📦 What is NTierArchitecture?

**NTierArchitecture** is a boilerplate solution demonstrating a clean and layered approach to .NET application development using N-Tier architecture. It separates concerns across layers such as **Presentation**, **Business**, **Data Access**, and **Entities**, making the codebase easier to scale, maintain, and test.

---

## 🧰 Technologies Used

| Technology            | Purpose                       |
| --------------------- | ----------------------------- |
| ASP.NET Core          | Web API layer                 |
| Entity Framework Core | Data persistence              |
| AutoMapper            | Object mapping between layers |
| FluentValidation      | Request validation            |
| .NET 8                | Core framework                |

---

## 🚀 Project Structure

```plaintext
📁 NTierArchitecture
|
├── 📁 NTierArchitecture.WebApi       → Presentation layer (Web API)
├── 📁 NTierArchitecture.Business     → Business logic and services
├── 📁 NTierArchitecture.DataAccess   → Data access layer (EF Core)
├── 📁 NTierArchitecture.Entities     → Domain entities and models
```

## ⚙️ Getting Started

1. Clone the Repository:

```bash
git clone https://github.com/taberkkaya/NTierArchitecture.git
cd NTierArchitecture
```

2. Update the connection string in `appsettings.json` under `NTierArchitecture.WebApi` project.

```json
"ConnectionStrings": {
  "SqlServer": "Your-SQL-Server-Connection-String-Here"
}
```

3. Run database migrations:

```bash
cd NTierArchitecture.DataAccess
dotnet ef database update
```

4. Run the API:

```bash
cd ..
dotnet run --project NTierArchitecture.WebApi
```

## ✅ Benefits

- Separation of concerns via clear layer boundaries
- Built-in support for validation and mapping
- Easily extensible and testable
- Clean dependency injection setup

---

### ✨ Contribution

> Feel free to fork this repository and contribute your improvements.

---

### 🪪 License

> This project is open-source and available under the MIT License.

---

<p align="center"> <img src="https://skillicons.dev/icons?i=dotnet,github,visualstudio" /> </p>
