using Microsoft.EntityFrameworkCore;

namespace TeejayInventory.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(db) {}
       
    }
}
