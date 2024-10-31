using TeejayInventory.Models;

namespace TeejayInventory.Interface
{
    public interface IWarehouseRepository : IRepository<Warehouse>
    {
        Task<Warehouse> UpdateAsync(Warehouse entity);
    }
}
