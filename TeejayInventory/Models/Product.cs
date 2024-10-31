namespace TeejayInventory.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public decimal  Price { get; set; }
        public string  Name { get; set; }
        public string SKU { get; set; }
        public int QuantityAvailable { get; set; }
    }
}
