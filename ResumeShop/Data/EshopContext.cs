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
        public DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoryToProduct>().HasKey(c => new { c.ProductId, c.CategoryId });

            //modelBuilder.Entity<Product>(
            //    p =>
            //    {
            //        p.HasKey(w => w.Id);
            //        p.OwnsOne<Item>(w => w.Item);
            //        p.HasOne<Item>(w => w.Item).WithOne(w => w.Product)
            //        .HasForeignKey<Item>(w => w.Id);
            //    }


            //    );


            modelBuilder.Entity<Item>(i =>
            {
                i.HasKey(w => w.Id);
                i.Property(w => w.Price).HasColumnType("Money");
            });


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



            modelBuilder.Entity<Item>().HasData(new Item()
            {
                Id = 1,
                Price = 33M,
                QuantityInStock = 4,
            }, new Item()
            {
                Id = 2,
                Price = 34M,
                QuantityInStock = 9,
            },new Item()
            {
                Id = 3,
                Price = 45M,
                QuantityInStock = 10,
            }

            );


            modelBuilder.Entity<Product>().HasData(
                new Product()
                {
                    Id = 1,
                    ItemId = 1,
                    Name = "گوشی موبایل iphone 13",
                    Description = "آیفون سیزده سی اچ پارت نامبر اروپا"
                }, new Product()
                {
                    Id = 2,
                    ItemId = 2,
                    Name = "گوشی موبایل iphone 12",
                    Description = "آیفون سیزده سی اچ پارت نامبر چین"
                }, new Product()
                {
                    Id = 3,
                    ItemId = 3,
                    Name = "گوشی موبایل iphone 11",
                    Description = "آیفون سیزده سی اچ پارت نامبر امریکا"
                }
                );

            modelBuilder.Entity<CategoryToProduct>().HasData(
                
                new CategoryToProduct() {CategoryId = 1, ProductId = 1 },
                new CategoryToProduct() { CategoryId = 2, ProductId = 1 },
                new CategoryToProduct() { CategoryId = 1, ProductId = 2 },
                new CategoryToProduct() { CategoryId = 3, ProductId = 2 },
                new CategoryToProduct() { CategoryId = 1, ProductId = 3 },
                new CategoryToProduct() { CategoryId = 4, ProductId = 1 }

                );

            #endregion

            base.OnModelCreating(modelBuilder);
        }

    }
}
