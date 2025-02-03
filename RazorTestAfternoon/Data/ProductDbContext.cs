using Microsoft.EntityFrameworkCore;

namespace RazorTestAfternoon.Data
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options)
            : base(options)
        {

        }

        public DbSet<Entities.Product> Products { get; set; }
    }
}
