using Microsoft.EntityFrameworkCore;
using InventoryManagementSystem.Models;

namespace InventoryManagementSystem.Data
{
    public class InventoryContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<StockTransaction> StockTransactions { get; set; }
        public DbSet<StockLevel> StockLevels { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(
                "server=localhost;database=InventoryDB;user=root;password=Swamiom11@",
                new MySqlServerVersion(new Version(8, 0, 36))
            );
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ToTable("product");
            modelBuilder.Entity<Warehouse>().ToTable("warehouse");

            modelBuilder.Entity<StockTransaction>()
                .ToTable("stocktransaction")
                .HasKey(s => s.TransactionId);

            modelBuilder.Entity<StockLevel>().ToTable("stocklevel");
        }


    }
}
