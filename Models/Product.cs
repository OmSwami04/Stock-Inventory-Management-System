namespace InventoryManagementSystem.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string? SKU { get; set; }
        public string? ProductName { get; set; }
        public int CategoryId { get; set; }
        public decimal Cost { get; set; }
        public decimal ListPrice { get; set; }
        public bool IsActive { get; set; }
        public int ReorderLevel { get; set; }

    }
}