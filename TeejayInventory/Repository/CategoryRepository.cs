using TeejayInventory.Data;
using TeejayInventory.Interface;
using TeejayInventory.Models;

namespace TeejayInventory.Repository
{
    public class CategoryRepository :Repository<Category>, ICategoryRepository
    {
        private readonly ApplicationDbContext _db;

        public CategoryRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public async Task<Category> UpdateAsync(Category entity)
        {
            // entity.UpdatedDate = DateTime.Now;
            _db.Categories.Update(entity);
            await _db.SaveChangesAsync();

            return entity;
        }
    }

}
