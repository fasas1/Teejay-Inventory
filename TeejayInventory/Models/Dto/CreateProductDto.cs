namespace TeejayInventory.Models.Dto
{
    public class CreateProductDto
    {
        public decimal Price { get; set; }
        public string Name { get; set; }
        public string SKU { get; set; }
        public int QuantityAvailable { get; set; }
    }
}
