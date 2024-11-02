using TeejayInventory.Models;

namespace TeejayInventory.Interface
{
    public interface ISupplierRepository : IRepository<Supplier>
    {
        Task<Supplier> UpdateAsync(Supplier entity);
    }
}
