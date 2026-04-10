[README.md](https://github.com/user-attachments/files/26640703/README.md)
# 🎓 EduResult Pro — Secondary School Result Management System

A full-stack web application built with **ASP.NET Core MVC** for managing secondary school academic results. Designed for administrators and teachers to manage students, classes, subjects, terms, and generate results efficiently.

---

## 📸 Screenshots

> Dashboard, Students, Result Entry — professional dark UI with role-based navigation.

---

## ✨ Features

### 👤 Authentication & Authorization
- Role-based access control — **Admin**, **Teacher**, **Student**
- Secure login using ASP.NET Core Identity
- JWT-ready architecture

### 🏫 Admin Panel
- Manage **Students** — enroll, view, delete
- Manage **Teachers** — create accounts with login access
- Manage **Classes** — SS1A, SS2B, etc.
- Manage **Subjects** — Mathematics, English, etc.
- Manage **Terms** — First Term 2024/2025, etc.
- Live **Dashboard** with real-time counts

### 📝 Result Management
- Enter **CA Score** (0–40) and **Exam Score** (0–60) per student
- Automatic **Total Score** and **Grade** computation
- Duplicate entry prevention per student/subject/term
- Results filtered by academic term

---

## 🛠️ Tech Stack

| Layer | Technology |
|-------|-----------|
| Framework | ASP.NET Core 8 MVC |
| Language | C# |
| Database | SQL Server (LocalDB) |
| ORM | Entity Framework Core |
| Auth | ASP.NET Core Identity |
| UI | Bootstrap 5 + Custom CSS |
| Icons | Bootstrap Icons |

---

## 🏗️ Architecture

```
Controllers (thin — HTTP only)
    ↓
Services (IResultService, IAdminService)
    ↓
DbContext (Entity Framework Core)
    ↓
SQL Server Database
```

- **Service Layer pattern** — business logic separated from controllers
- **Repository-style services** with interface abstractions
- **ViewModels** for all form inputs — entities never exposed directly

---

## 🚀 Getting Started

### Prerequisites
- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- SQL Server or LocalDB
- Visual Studio 2022+

### Setup

1. **Clone the repository**
```bash
git clone https://github.com/hassanahmad444/Secondary-School-Result-Management-System.git
cd Secondary-School-Result-Management-System
```

2. **Configure the database**

Copy `appsettings.example.json` to `appsettings.json` and update the connection string:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "your-sql-server-connection-string"
  }
}
```

3. **Apply migrations**
```bash
dotnet ef database update
```

4. **Run the application**
```bash
dotnet run
```

5. **Login with default admin account**
```
Email: admin@school.com
Password: Admin@123
```

---

## 📁 Project Structure

```
├── Controllers/          # Thin controllers — delegate to services
├── Service/              # Business logic (IAdminService, IResultService)
├── Models/Entities/      # Domain models (Student, Teacher, Result, etc.)
├── ViewModel/            # Form input models with validation
├── Data/                 # DbContext and EF Core configuration
├── Views/                # Razor views (Admin, Result, Home)
├── Roles/                # Role constants
└── Migrations/           # EF Core database migrations
```

---

## 🗄️ Data Model

```
Student ──────── SchoolClass
    │
    └── Result ──── Subject
            │
            └── Term

Teacher ──────── TeacherSubjectClass ──── Subject
                                    └─── SchoolClass
```

---

## 🔐 Default Roles

| Role | Access |
|------|--------|
| Admin | Full system access — manage all entities |
| Teacher | Enter and view results |
| Student | View own results |

---

## 🧪 Grading System

| Score | Grade |
|-------|-------|
| 70–100 | A |
| 60–69 | B |
| 50–59 | C |
| 40–49 | D |
| 0–39 | F |

---

## 👨‍💻 Author

**Hassan Ahmad**
- GitHub: [@hassanahmad444](https://github.com/hassanahmad444)

---

## 📄 License

This project is open source and available under the [MIT License](LICENSE).
