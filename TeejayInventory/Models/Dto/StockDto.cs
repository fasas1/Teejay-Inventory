using System.Text.Json.Serialization;

namespace TeejayInventory.Models.Dto
{
    public class StockDto
    {
        public int StockId { get; set; }
        public int Quantity { get; set; }
        public DateTime LastUpdated { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int WarehouseId { get; set; }
        [JsonIgnore]
        public Warehouse Warehouse { get; set; }

    }
}
