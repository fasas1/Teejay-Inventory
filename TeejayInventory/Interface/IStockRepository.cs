using TeejayInventory.Models;

namespace TeejayInventory.Interface
{
    public interface IStockRepository : IRepository<Stock>
    {
        Task<Stock> UpdateAsync(Stock entity);
    }
}
