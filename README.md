# 🛒 Marketplace Project

A modular **Clean Architecture**-based marketplace application built with separation of concerns in mind.  
The project is divided into four main layers: **Domain**, **Application**, **Infrastructure**, and **Presentation**.

---

## 🧱 Project Structure

```plaintext
Marketplace/
├── Domain/
│   ├── User.cs
│   ├── Item.cs
│
├── Application/
│   ├── Interfaces/
│   │   ├── IUserService.cs
│   │   ├── IUserRepository.cs
│   │   ├── IItemService.cs
│   │   └── IItemRepository.cs
│
├── Infrastructure/
│   ├── Services/
│   │   ├── UserService.cs
│   │   └── ItemService.cs
│   ├── Repositories/
│   │   ├── UserRepository.cs
│   │   └── ItemRepository.cs
│   ├── Database/
│   │   └── DatabaseHandler.cs
│
└── Presentation/
    ├── Controllers/
    │   └── UserController.cs
    ├── Program.cs
```

## 🧩 Domain Layer

The **Domain** layer defines the **core business models** and entities used throughout the project.

- `User` – represents a user entity.
- `Item` – represents an item or product entity.

---

## ⚙️ Application Layer

The **Application** layer defines the **interfaces** that describe the expected behavior of services and repositories.

- `IUserService`
- `IUserRepository`
- `IItemService`
- `IItemRepository`

These interfaces act as **contracts** between the business logic and the infrastructure.

---

## 🏗️ Infrastructure Layer

The **Infrastructure** layer provides **concrete implementations** for the interfaces defined in the Application layer.

Includes:
- `UserService`, `ItemService`
- `UserRepository`, `ItemRepository`
- `DatabaseHandler` for managing database operations

---

## 🖥️ Presentation Layer

The **Presentation** layer handles **user requests**, **controllers**, and **application entry points**.

- `UserController` is the main controller managing user-related requests.

---

## 🚀 How to Run

```bash
# Clone the repository
git clone https://github.com/<your-username>/marketplace.git

# Navigate to the project folder
cd marketplace

# Build and run
dotnet run  # or use your build system
