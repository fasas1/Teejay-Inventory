namespace TeejayInventory.Models.Dto
{
    public class UpdateStockDto
    {
        public int StockId { get; set; }
        public int ProductId { get; set; }
        public int WarehouseId { get; set; }
        public int Quantity { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
