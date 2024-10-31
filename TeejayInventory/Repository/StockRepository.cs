using TeejayInventory.Data;
using TeejayInventory.Interface;
using TeejayInventory.Models;

namespace TeejayInventory.Repository
{
    public class StockRepository :Repository<Stock>, IStockRepository
    {
        private readonly ApplicationDbContext _db;

        public StockRepository(ApplicationDbContext db) :base(db)
        {
            _db = db;
        }
        public async Task<Stock> UpdateAsync(Stock entity)
        {
            // entity.UpdatedDate = DateTime.Now;
            _db.Stocks.Update(entity);
            await _db.SaveChangesAsync();

            return entity;
        }
    }
}
