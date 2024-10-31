using TeejayInventory.Models;

namespace TeejayInventory.Interface
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<Category> UpdateAsync(Category entity);
    }
}
