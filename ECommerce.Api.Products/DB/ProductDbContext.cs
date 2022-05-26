using Microsoft.EntityFrameworkCore;

namespace ECommerce.Api.Products.DB
{
    public class ProductDbContext : DbContext
    {
        public DbSet<ProductEntity> Products { get; set; }

        public ProductDbContext(DbContextOptions<ProductDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductEntityConfig());
        }
    }
}
