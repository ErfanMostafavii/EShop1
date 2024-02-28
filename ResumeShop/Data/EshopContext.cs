using Microsoft.EntityFrameworkCore;
using ResumeShop.Models;

namespace ResumeShop.Data
{
    public class EshopContext : DbContext
    {
        public EshopContext(DbContextOptions<EshopContext> options) : base(options)
        {

        }
        public DbSet<Category> categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<CategoryToProduct> CategoryToProducts { get; set; }
        public DbSet<Item> Items { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoryToProduct>().HasKey(c => new { c.ProductId, c.CategoryId });
            #region SeedData

            modelBuilder.Entity<Category>().HasData(new Category()
            {
                Id = 1,
                Name = "سامسونگ",
                Description = "لوازم سامسونگ"

            }, new Category()
            {
                Id = 2,
                Name = "هواوی",
                Description = "لوازم هواوی",
            }, new Category()
            {
                Id = 3,
                Name = "شیاومی",
                Description = "لوازم شیایومی",
            }, new Category()
            {
                Id = 4,
                Name = "اپل",
                Description = "لوازم اپل",
            }





            );

            #endregion
            base.OnModelCreating(modelBuilder);
        }

    }
}
