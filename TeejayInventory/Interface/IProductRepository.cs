using TeejayInventory.Models;

namespace TeejayInventory.Interface
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<Product> UpdateAsync(Product entity);
    }
}
