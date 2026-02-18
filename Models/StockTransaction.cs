namespace InventoryManagementSystem.Models
{
    public class StockTransaction
    {
        public int TransactionId { get; set; }   // PRIMARY KEY

        public int ProductId { get; set; }
        public int WarehouseId { get; set; }
        public string? TransactionType { get; set; }
        public int Quantity { get; set; }
        public DateTime TransactionDate { get; set; }
        public string? Reference { get; set; }
    }
}
