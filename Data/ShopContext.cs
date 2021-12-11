using Microsoft.EntityFrameworkCore;
using ProducttAPI.Models;

namespace ProducttAPI.Data
{
    public class ShopContext : DbContext
    {
        public ShopContext(DbContextOptions<ShopContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasMany(c => c.Products).WithOne(p => p.Category).HasForeignKey(p => p.CategoryId);
            modelBuilder.Entity<User>().HasMany(u => u.Orders).WithOne(o => o.User).HasForeignKey(o => o.UserId);
            modelBuilder.Entity<Order>().HasMany(o => o.Products);
            modelBuilder.Entity<Order>().HasOne(o => o.User);

            modelBuilder.Seed();
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Category> Categories { get; set; }
    }
}

