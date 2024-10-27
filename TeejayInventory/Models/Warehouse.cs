namespace TeejayInventory.Models
{
    public class Warehouse
    {
        public int WarehouseId { get; set; }
        public string Location { get; set; }
        public List<Stock> Stocks { get; set; }
    }
}
