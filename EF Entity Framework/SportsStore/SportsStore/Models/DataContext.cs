using Microsoft.EntityFrameworkCore;

namespace SportsStore.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> opts) : base(opts)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }
        public DbSet<Price> Prices { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasIndex(p => p.Name);
            modelBuilder.Entity<Product>().HasIndex(p => p.PurchasePrice);
            modelBuilder.Entity<Product>().HasIndex(p => p.RetailPrice);


            modelBuilder.Entity<Category>().HasIndex(p => p.Name);
            modelBuilder.Entity<Category>().HasIndex(p => p.Description);

           modelBuilder.Entity<Price>().HasOne(p => p.Product).WithMany(b => b.Prices);
        }
    }
}
