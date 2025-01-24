using Microsoft.EntityFrameworkCore;

namespace MenuManager.Models.Context
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        public MyDbContext() : base() { }

        public DbSet<CatalogManagement.Models.Entities.User> Users { get; set; }
        public DbSet<CatalogManagement.Models.Entities.Apparel> Apparels { get; set; }
        public DbSet<CatalogManagement.Models.Entities.Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies(true);
        }
    }
}
