namespace InventoryManagementSystem.Models
{
    public class StockLevel
    {
        public int StockLevelId { get; set; }
        public int ProductId { get; set; }
        public int WarehouseId { get; set; }
        public int QuantityOnHand { get; set; }
        public int ReorderLevel { get; set; }
        public int SafetyStock { get; set; }
    }
}
