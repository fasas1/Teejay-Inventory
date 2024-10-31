namespace TeejayInventory.Models.Dto
{
    public class WarehouseDto
    {
        public int WarehouseId { get; set; }
        public string Location { get; set; }
        public List<Stock> Stocks { get; set; }
    }
}
