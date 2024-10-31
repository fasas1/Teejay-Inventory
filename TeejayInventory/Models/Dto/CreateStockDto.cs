namespace TeejayInventory.Models.Dto
{
    public class CreateStockDto
    {
        public int ProductId { get; set; }
        public int WarehouseId { get; set; }
        public int Quantity { get; set; }
       
    }
}
