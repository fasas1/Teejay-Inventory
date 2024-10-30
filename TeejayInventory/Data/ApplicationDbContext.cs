using Microsoft.EntityFrameworkCore;
using TeejayInventory.Models;

namespace TeejayInventory.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Product> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    ProductId = 1,
                    Price = 620000,
                    Name = "Sony Television",
                    SKU = "SKU001",
                    QuantityAvailable = 85

                },
                 new Product
                 {
                     ProductId = 2,
                     Price = 26000,
                     Name = "Iron",
                     SKU = "SKU002",
                     QuantityAvailable = 550
                 },
                 new Product
                 {
                     ProductId = 3,
                     Price = 120000,
                     Name = "LG Fan",
                     SKU = "SKU003",
                     QuantityAvailable = 323

                 },
                   new Product
                   {
                       ProductId = 4,
                       Price = 480000,
                       Name = "Electric Cooker",
                       SKU = "SKU004",
                       QuantityAvailable = 94

                   },
                  new Product
                  {
                      ProductId = 5,
                      Price = 320000,
                      Name = "Washing Machine", 
                      SKU = "SKU005",
                      QuantityAvailable = 181

                  }

             );
            modelBuilder.Entity<Warehouse>().HasData(
                new Warehouse { WarehouseId = 1, Location = "Ikeja" },
                   new Warehouse { WarehouseId = 2, Location = "Sango ota" },
                      new Warehouse { WarehouseId = 3, Location = "Lekki" }
                 );
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, Name = "Smart TV", Description = "Smart and OLED Screen Television" },
                new Category { CategoryId = 2, Name = "Iron", Description = "Strong and Durable Pressing Iron" },
                new Category { CategoryId = 3, Name = "Washing Machine", Description = "AI Powered Washing Machine" }
              );
            modelBuilder.Entity<Supplier>().HasData(
            new Supplier { SupplierId = 1, Name = "Choing Exporter", Email = "choing@gmail.com" , PhoneNumber= "477892002340"},
               new Supplier { SupplierId = 2, Name = "Tchang Inc", Email = "tchangsupply@gmail.com", PhoneNumber = "774292002340" }
        );
            modelBuilder.Entity<Transaction>().HasData(
            new Transaction { TransactionId = 1, ProductId = 4, Quantity = 340, TransactionDate = DateTime.UtcNow, TransactionType = "Purchase" },
             new Transaction { TransactionId = 2, ProductId = 2, Quantity = 70, TransactionDate = DateTime.UtcNow, TransactionType = "Sale" }
        );
            modelBuilder.Entity<Stock>().HasData(
              new Stock { StockId = 1, ProductId =1, WarehouseId = 2, Quantity= 143, LastUpdated = DateTime.UtcNow, }
                );
        }
    }
}
