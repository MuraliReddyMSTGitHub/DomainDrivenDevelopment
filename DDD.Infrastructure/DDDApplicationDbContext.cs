using DDD.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DDD.Infrastructure
{
    public class DDDApplicationDbContext : DbContext
    {
        public DDDApplicationDbContext(DbContextOptions<DDDApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Product> Producuts { get; set; }

        public DbSet<ProductCategory> ProductCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
