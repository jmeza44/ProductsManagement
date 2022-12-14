using Microsoft.EntityFrameworkCore;
using ProductsManagement.Data.Models;

namespace ProductsManagement.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}
