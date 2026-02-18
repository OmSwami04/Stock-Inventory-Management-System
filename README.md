# 📦 Stock Inventory Management System (.NET)

---

## 📌 Project Overview

The **Stock Inventory Management System** is a .NET-based application designed to manage product inventory efficiently by tracking stock levels, inventory transactions, and warehouse information.

This system helps businesses maintain accurate inventory records and automate stock monitoring processes.

---

## 🎯 Objective

To develop an Inventory Management System that allows:

* Product management
* Stock level monitoring
* Inventory transaction tracking
* Warehouse management
* Database integration using Entity Framework

---

## 🛠️ Technology Stack

| Technology              | Description             |
| ----------------------- | ----------------------- |
| C# (.NET)               | Application Development |
| Entity Framework Core   | ORM                     |
| MySQL / SQL Server      | Database                |
| Visual Studio 2022/2026 | IDE                     |

---

## ✨ Key Features

* Product Management
* Warehouse Management
* Stock Level Tracking
* Stock In / Stock Out Transactions
* Inventory Movement Tracking
* Database Integration

---

## 📁 Project Structure

```
Project/
│
├── Data/
│   └── InventoryContext.cs
│
├── Database/
│   └── InventoryDB.sql
│
├── Models/
│   ├── Product.cs
│   ├── StockLevel.cs
│   ├── StockTransaction.cs
│   └── Warehouse.cs
│
├── Program.cs
├── .gitignore
└── README.md
```

---

## 🗄️ Database Setup

### Step 1: Create Database

Run the following query in MySQL / SQL Server:

```sql
CREATE DATABASE InventoryDB;
```

### Step 2: Execute Database Script

Run:

```
Database/InventoryDB.sql
```

This will create:

* Product Table
* Warehouse Table
* StockLevel Table
* StockTransaction Table

---

## ▶️ How to Run the Project

### Step 1: Clone Repository

```bash
git clone https://github.com/OmSwami04/Stock-Inventory-Management-System.git
```

### Step 2: Open Project

* Open `.sln` file in Visual Studio

### Step 3: Build Solution

Press:

```
Ctrl + Shift + B
```

### Step 4: Run Application

Press:

```
Ctrl + F5
```

---

## 🚀 Future Enhancements

* Barcode Integration
* QR Code-Based Billing
* Low Stock Alerts
* Expiry Notifications
* Dashboard Reports

---

## 👨‍💻 Author

**Om Swami**


---

## 📄 License

This project is for educational purposes only.
