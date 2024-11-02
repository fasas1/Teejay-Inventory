using TeejayInventory.Data;
using TeejayInventory.Interface;
using TeejayInventory.Models;

namespace TeejayInventory.Repository
{
    public class SupplierRepository :Repository<Supplier>, ISupplierRepository
    {
        private readonly ApplicationDbContext _db;

        public SupplierRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public async Task<Supplier> UpdateAsync(Supplier entity)
        {
            // entity.UpdatedDate = DateTime.Now;
            _db.Suppliers.Update(entity);
            await _db.SaveChangesAsync();

            return entity;
        }
    }

}
