using InventoryManagementSystem.Data;
using InventoryManagementSystem.Models;
using System;
using System.Linq;

InventoryContext context = new InventoryContext();

try
{
    if (!context.Database.CanConnect())
    {
        Console.WriteLine("Database Connection Failed!");
        return;
    }

    Console.WriteLine("Database Connected Successfully!");

    // ---------------- PRODUCT INSERT ----------------

    var existingProduct = context.Products
        .FirstOrDefault(p => p.SKU == "MED900");

    if (existingProduct == null)
    {
        Product p = new Product()
        {
            SKU = "MED900",
            ProductName = "Paracetamol",
            CategoryId = 1,
            Cost = 10,
            ListPrice = 15,
            IsActive = true,
            ReorderLevel = 60
        };

        context.Products.Add(p);
        context.SaveChanges();
        Console.WriteLine("New Product Inserted Successfully!");
    }
    else
    {
        Console.WriteLine("Product Already Exists!");
    }

    // ---------------- WAREHOUSE INSERT ----------------

    if (!context.Warehouses.Any(w => w.WarehouseName == "Main Store"))
    {
        context.Warehouses.Add(new Warehouse
        {
            WarehouseName = "Main Store",
            Location = "Solapur",
            Capacity = 1000
        });
        context.SaveChanges();
    }

    if (!context.Warehouses.Any(w => w.WarehouseName == "Backup Store"))
    {
        context.Warehouses.Add(new Warehouse
        {
            WarehouseName = "Backup Store",
            Location = "Pune",
            Capacity = 500
        });
        context.SaveChanges();
    }

    // ---------------- STOCK IN ----------------

    if (!context.StockTransactions.Any(t => t.Reference == "Purchase"))
    {
        var stockIn = new StockTransaction
        {
            ProductId = 1,
            WarehouseId = 1,
            TransactionType = "IN",
            Quantity = 100,
            TransactionDate = DateTime.Now,
            Reference = "Purchase"
        };

        context.StockTransactions.Add(stockIn);
        context.SaveChanges();

        var stockLevel = context.StockLevels
            .FirstOrDefault(s => s.ProductId == 1 && s.WarehouseId == 1);

        if (stockLevel == null)
        {
            stockLevel = new StockLevel
            {
                ProductId = 1,
                WarehouseId = 1,
                QuantityOnHand = stockIn.Quantity,
                ReorderLevel = 60,
                SafetyStock = 20
            };
            context.StockLevels.Add(stockLevel);
        }
        else
        {
            stockLevel.QuantityOnHand += stockIn.Quantity;
        }

        context.SaveChanges();
    }

    // ---------------- STOCK OUT ----------------

    if (!context.StockTransactions.Any(t => t.Reference == "Sale"))
    {
        var stockOut = new StockTransaction
        {
            ProductId = 1,
            WarehouseId = 1,
            TransactionType = "OUT",
            Quantity = 20,
            TransactionDate = DateTime.Now,
            Reference = "Sale"
        };

        context.StockTransactions.Add(stockOut);
        context.SaveChanges();

        var stockLevel = context.StockLevels
            .FirstOrDefault(s => s.ProductId == 1 && s.WarehouseId == 1);

        stockLevel.QuantityOnHand -= stockOut.Quantity;
        context.SaveChanges();
    }

    // ---------------- PURCHASE ORDER ----------------

    if (!context.StockTransactions.Any(t => t.Reference == "PO001"))
    {
        var po = new StockTransaction
        {
            ProductId = 1,
            WarehouseId = 1,
            TransactionType = "IN",
            Quantity = 50,
            TransactionDate = DateTime.Now,
            Reference = "PO001"
        };

        context.StockTransactions.Add(po);
        context.SaveChanges();

        var stockLevel = context.StockLevels
            .FirstOrDefault(s => s.ProductId == 1 && s.WarehouseId == 1);

        stockLevel.QuantityOnHand += po.Quantity;
        context.SaveChanges();
    }

    // ---------------- STOCK TRANSFER ----------------

    if (!context.StockTransactions.Any(t => t.Reference == "Transfer"))
    {
        context.StockTransactions.AddRange(
            new StockTransaction
            {
                ProductId = 1,
                WarehouseId = 1,
                TransactionType = "OUT",
                Quantity = 10,
                TransactionDate = DateTime.Now,
                Reference = "Transfer"
            },
            new StockTransaction
            {
                ProductId = 1,
                WarehouseId = 2,
                TransactionType = "IN",
                Quantity = 10,
                TransactionDate = DateTime.Now,
                Reference = "Transfer"
            }
        );
        context.SaveChanges();

        var mainStock = context.StockLevels
            .FirstOrDefault(s => s.ProductId == 1 && s.WarehouseId == 1);

        var backupStock = context.StockLevels
            .FirstOrDefault(s => s.ProductId == 1 && s.WarehouseId == 2);

        mainStock.QuantityOnHand -= 10;

        if (backupStock == null)
        {
            backupStock = new StockLevel
            {
                ProductId = 1,
                WarehouseId = 2,
                QuantityOnHand = 10,
                ReorderLevel = 60,
                SafetyStock = 20
            };
            context.StockLevels.Add(backupStock);
        }
        else
        {
            backupStock.QuantityOnHand += 10;
        }

        context.SaveChanges();
    }

    // ---------------- CURRENT STOCK ----------------

    var finalStock = context.StockLevels
        .FirstOrDefault(s => s.ProductId == 1 && s.WarehouseId == 1);

    Console.WriteLine("Current Stock = " + finalStock.QuantityOnHand);

    if (finalStock.QuantityOnHand <= finalStock.ReorderLevel)
        Console.WriteLine("⚠ LOW STOCK ALERT!");
    else
        Console.WriteLine("Stock level is safe.");

    // ---------------- FIFO ----------------

    var fifoTransactions = context.StockTransactions
        .Where(t => t.ProductId == 1 && t.TransactionType == "IN")
        .OrderBy(t => t.TransactionDate)
        .ToList();

    var product = context.Products.FirstOrDefault(p => p.ProductId == 1);
    decimal fifoValue = fifoTransactions.Sum(t => t.Quantity * product.Cost);

    Console.WriteLine("FIFO Inventory Value = " + fifoValue);

    // ---------------- ABC ----------------

    Console.WriteLine("\nABC Analysis:");
    foreach (var item in context.Products.ToList())
    {
        string category =
            item.Cost >= 1000 ? "A"
          : item.Cost >= 500 ? "B"
          : "C";

        Console.WriteLine($"{item.ProductName} - Category {category}");
    }

    // ---------------- STOCK AGING ----------------

    Console.WriteLine("\nStock Aging Report:");
    var agingData = context.StockTransactions
        .Where(t => t.ProductId == 1 && t.TransactionType == "IN")
        .ToList();

    foreach (var item in agingData)
    {
        int age = (DateTime.Now - item.TransactionDate).Days;
        string status = age <= 30 ? "Fresh" : age <= 60 ? "Moderate" : "Old";

        Console.WriteLine($"Qty: {item.Quantity} - Age: {age} Days - {status}");
    }

    // ---------------- INVENTORY TURNOVER ----------------

    var totalOut = context.StockTransactions
        .Where(t => t.ProductId == 1 && t.TransactionType == "OUT")
        .Sum(t => t.Quantity);

    double turnover = finalStock.QuantityOnHand > 0
        ? (double)totalOut / finalStock.QuantityOnHand
        : 0;

    Console.WriteLine("\nInventory Turnover Ratio = " + turnover);
}
catch (Exception ex)
{
    Console.WriteLine("Main Error: " + ex.Message);
    Console.WriteLine("Inner Error: " + ex.InnerException?.Message);
}
