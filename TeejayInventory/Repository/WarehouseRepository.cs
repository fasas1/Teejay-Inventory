using TeejayInventory.Data;
using TeejayInventory.Interface;
using TeejayInventory.Models;

namespace TeejayInventory.Repository
{
    public class WarehouseRepository : Repository<Warehouse>, IWarehouseRepository
    {
        private readonly ApplicationDbContext _db;

        public WarehouseRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public async Task<Warehouse> UpdateAsync(Warehouse entity)
        {
            // entity.UpdatedDate = DateTime.Now;
            _db.Warehouses.Update(entity);
            await _db.SaveChangesAsync();

            return entity;
        }
    }
}
