# Stock-Inventory-Management-System
# 📦 Stock Inventory Management System

## 📌 Project Overview

The **Stock Inventory Management System** is a .NET-based desktop application developed to efficiently manage product inventory, track stock levels, monitor inventory transactions, and integrate quotations and invoices.
This system helps businesses maintain accurate stock records and reduce manual inventory management errors.

---

## 🎯 Business Objective

To develop an inventory management system that enables:

* Product tracking
* Stock level monitoring
* Inventory transaction management
* Integration with quotations and invoices

---

## 🛠️ Technology Stack

| Technology              | Description                  |
| ----------------------- | ---------------------------- |
| .NET (C#)               | Application Development      |
| Entity Framework        | ORM for Database Integration |
| MySQL / SQL Server      | Database Management          |
| Visual Studio 2022/2026 | Development IDE              |

---

## ✨ Features

### 📂 Product Catalog Management

* Add new products
* Update product details
* Categorize products
* Maintain SKU, Name, Description, Category, Unit

### 📊 Stock Management

* Monitor stock levels
* Track stock availability
* Update stock quantities

### 📈 Inventory Transactions

* Record stock-in and stock-out
* Track inventory movement
* Maintain transaction history

### 🧾 Quotation & Invoice Integration

* Generate quotations
* Generate invoices
* Maintain billing records

---

## 📁 Project Structure

```
InventoryManagementSystem/
│
├── ConsoleApp1/
│   ├── Program.cs
│   ├── DelegateDemo.cs
│   ├── EventHandler_exp.cs
│   └── Assignment.cs
│
├── Database/
│   └── InventoryDB.sql
│
├── InventoryManagementSystem.csproj
├── InventoryManagementSystem.sln
└── .gitignore
```

---

## 🗄️ Database Setup

1. Open your MySQL / SQL Server
2. Create a new database:

```sql
CREATE DATABASE InventoryDB;
```

3. Run the script:

```
Database/InventoryDB.sql
```

This will create all necessary tables required for the system.

---

## ▶️ How to Run the Project

### Step 1: Clone Repository

```bash
git clone https://github.com/OmSwami04/Stock-Inventory-Management-System.git
```

### Step 2: Open in Visual Studio

* Open `.sln` file
* Build the solution

### Step 3: Run Application

* Press **Ctrl + F5** to run the project

---

## 📌 Git Workflow Used

```bash
git add .
git commit -m "Commit Message"
git pull --rebase origin main
git push
```

---

## 🚀 Future Enhancements

* Barcode Integration
* QR Code-Based Billing
* Expiry Alerts
* Low Stock Notifications
* Dashboard Analytics

---

## 👨‍💻 Author

**Om Swami**

---

## 📄 License

This project is developed for educational and academic purposes.
