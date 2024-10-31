namespace TeejayInventory.Models.Dto
{
    public class CreateWarehouseDto
    {
        public string Location { get; set; }
        public List<Stock> Stocks { get; set; }
    }
}
