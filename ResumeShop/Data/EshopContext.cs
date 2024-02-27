using Microsoft.EntityFrameworkCore;
using ResumeShop.Models;

namespace ResumeShop.Data
{
    public class EshopContext : DbContext
    {
        public EshopContext(DbContextOptions<EshopContext> options):base(options)
        {
            
        }
        public DbSet<Category> categories { get; set; } 

    }
}
