CREATE DATABASE InventoryDB;
USE InventoryDB;

CREATE TABLE ProductCategory (
    CategoryId INT AUTO_INCREMENT PRIMARY KEY,
    CategoryName VARCHAR(100) NOT NULL,
    Description VARCHAR(200),
    ParentCategoryId INT,
    FOREIGN KEY (ParentCategoryId)
    REFERENCES ProductCategory(CategoryId)
    ON DELETE SET NULL
);

CREATE TABLE Supplier (
    SupplierId INT AUTO_INCREMENT PRIMARY KEY,
    SupplierName VARCHAR(100) NOT NULL,
    Email VARCHAR(100),
    Phone VARCHAR(20),
    Website VARCHAR(100)
);

CREATE TABLE Product (
    ProductId INT AUTO_INCREMENT PRIMARY KEY,
    SKU VARCHAR(50) UNIQUE,
    ProductName VARCHAR(100) NOT NULL,
    Description VARCHAR(200),
    CategoryId INT,
    UnitOfMeasure VARCHAR(20),
    Cost DECIMAL(10,2),
    ListPrice DECIMAL(10,2),
    IsActive BOOLEAN DEFAULT TRUE,
    FOREIGN KEY (CategoryId)
    REFERENCES ProductCategory(CategoryId)
);

CREATE TABLE ProductSupplier (
    SupplierProductId INT AUTO_INCREMENT PRIMARY KEY,
    ProductId INT,
    SupplierId INT,
    SupplierSKU VARCHAR(50),
    LeadTime INT,
    FOREIGN KEY (ProductId) REFERENCES Product(ProductId),
    FOREIGN KEY (SupplierId) REFERENCES Supplier(SupplierId)
);

CREATE TABLE Warehouse (
    WarehouseId INT AUTO_INCREMENT PRIMARY KEY,
    WarehouseName VARCHAR(100),
    Location VARCHAR(200),
    Capacity INT
);


CREATE TABLE StockLevel (
    StockLevelId INT AUTO_INCREMENT PRIMARY KEY,
    ProductId INT,
    WarehouseId INT,
    QuantityOnHand INT DEFAULT 0,
    ReorderLevel INT,
    SafetyStock INT,
    FOREIGN KEY (ProductId) REFERENCES Product(ProductId),
    FOREIGN KEY (WarehouseId) REFERENCES Warehouse(WarehouseId)
);

CREATE TABLE StockTransaction (
    TransactionId INT AUTO_INCREMENT PRIMARY KEY,
    ProductId INT,
    WarehouseId INT,
    TransactionType ENUM('IN','OUT','ADJUSTMENT','TRANSFER'),
    Quantity INT,
    TransactionDate DATETIME DEFAULT CURRENT_TIMESTAMP,
    Reference VARCHAR(50),
    FOREIGN KEY (ProductId) REFERENCES Product(ProductId),
    FOREIGN KEY (WarehouseId) REFERENCES Warehouse(WarehouseId)
);

SELECT * FROM ProductCategory;
DESCRIBE Product;

INSERT INTO ProductCategory(CategoryName)
VALUES ('Medical');

select * from product

ALTER USER 'root'@'localhost'
IDENTIFIED WITH mysql_native_password
BY 'Swamiom11@';

FLUSH PRIVILEGES;


ALTER TABLE product
ADD ReorderLevel INT DEFAULT 50;

UPDATE product
SET ReorderLevel = 60
WHERE ProductId = 1;

UPDATE stocklevel
SET QuantityOnHand = 0
WHERE ProductId = 1 AND WarehouseId = 1;

SELECT * FROM stocklevel;

DELETE FROM stocktransaction;
