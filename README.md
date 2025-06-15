# 🥗 HealthyFood - ASP.NET Core 8.0 MVC E-Commerce Platform

**HealthyFood** is a modern ASP.NET Core 8.0 MVC web application designed for browsing and purchasing healthy food products online. It offers a complete e-commerce experience with secure user authentication, a dynamic product catalog, a session-based shopping cart, and admin product management tools.

---

## 📌 Purpose & Scope

This application enables:
- Customers to browse healthy food products, manage their carts, and place orders.
- Admins to manage products and categories.
- Secure user registration and login using ASP.NET Core Identity.
- A responsive and interactive user interface using modern frontend tools.

---

## 🏛️ System Architecture

HealthyFood follows a layered MVC architecture:

Presentation Layer (Views, _CustomLayout.cshtml)
│
├── Controllers (Home, Product, Cart, Account, Admin)
│
├── Business Logic Layer (Repositories, Services)
│
└── Data Access Layer (EF Core, AppDbContext, SQL Server)



---

## 📂 Relevant Source Files

| File/Folder                                | Purpose                                 |
|-------------------------------------------|-----------------------------------------|
| `HealthyFood/Program.cs`                  | App startup, middleware configuration   |
| `HealthyFood/Views/Shared/_CustomLayout.cshtml` | Master layout and navigation       |
| `HealthyFood/Controllers/`                | Core MVC Controllers                    |
| `HealthyFood/Models/Repositories/`        | Repository Interfaces & Implementations |
| `HealthyFood/Data/AppDbContext.cs`        | Entity Framework DB context             |

---

## ⚙️ Technology Stack

| Category         | Technology                      | Description                          |
|------------------|----------------------------------|--------------------------------------|
| **Backend**      | ASP.NET Core 8.0 MVC             | Web framework                        |
|                  | ASP.NET Core Identity            | Authentication & Authorization       |
|                  | Entity Framework Core 8.0       | ORM & data access                    |
| **Database**     | SQL Server                       | Persistent storage                   |
| **Frontend**     | Bootstrap 5.0                    | Responsive UI                        |
|                  | jQuery 3.4.1                     | DOM Manipulation                     |
|                  | Font Awesome, Bootstrap Icons   | Iconography                          |
|                  | Animate.css + WOW.js             | UI animations                        |
| **Storage**      | ASP.NET Core Sessions            | Session-based cart persistence       |
| **Serialization**| Newtonsoft.Json 13.0.3           | JSON serialization                   |

---

## 🔑 Core Functional Areas

### 1. 🛍️ Product Management System
- **Controllers:** `ProductController`, `AdminController`
- **Features:** Browse, search, filter products; admin CRUD

### 2. 👥 User Authentication System
- **Controller:** `AccountController`
- **Features:** Registration, login, secure session handling

### 3. 🛒 Shopping Cart System
- **Controller:** `CartController`
- **Features:** Add/remove items, manage quantities, checkout

### 4. 🏠 Static Content Pages
- **Controller:** `HomeController`
- **Features:** Home, About, Contact pages

---

## 🔁 Request Processing Flow

**Product Catalog:**
GET /Product
→ ProductController.Index()
→ IProductRepo.GetPagedProductsAsync()
→ AppDbContext.Products
→ SQL Server Query
→ ViewResult (HTML page)

**Cart Operations (AJAX):**
POST /Cart/AddToCart
→ CartController.AddToCart()
→ Store in Session
→ JSON Response (cart updated)


---

## 🧭 Navigation Structure

Implemented via `_CustomLayout.cshtml` with active link highlighting.

| Page          | Controller/Action           |
|---------------|------------------------------|
| Home          | `HomeController.Index`       |
| Products      | `ProductController.Index`    |
| About Us      | `HomeController.About`       |
| Contact Us    | `HomeController.Contact`     |
| Login/Register| `AccountController.Login`    |
| Cart          | `CartController.Index`       |

---

## 🗃️ Database Entities

- `Users` (ASP.NET Identity)
- `Products`
- `Categories`
- `Orders`
- `OrderDetails`
- `Reviews`

---

## ✅ How to Run the Project

1. Clone the repository
2. Set up your SQL Server connection string in `appsettings.json`
3. Run migrations:
4. Run the app:

5. Navigate to `https://localhost:{port}`

---

## 🧑‍💻 Contributors

- **Santy Osama** – Developer & Project Lead  
- **Hossam Adel** – Developer



