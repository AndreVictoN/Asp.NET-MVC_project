using Microsoft.EntityFrameworkCore;
using FiapOnSmartCity.Models;

namespace FiapOnSmartCity.DAL.Context;

public class ContextClass : DbContext
{
    private readonly string _connectionString;
    
    public ContextClass()
    {
        _connectionString = Environment.GetEnvironmentVariable("LocalConnection");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseOracle(_connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.HasDefaultSchema("SYSTEM");

        modelBuilder.Entity<ProductType>(entity =>
        {
            entity.ToTable("PRODUCT_TYPE").HasKey(p => p.id);
            entity.Property(p => p.id).HasColumnName("IDPRODUCT");
            entity.Property(p => p.description).HasColumnName("PROD_DESCRIPTION").HasMaxLength(50).IsRequired();
            entity.Property(p => p.isComercialized).HasColumnName("IS_COMERCIALIZED").HasConversion<int>();
        });

        modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("PRODUCT").HasKey(p => p.id);
                entity.Property(p => p.id).HasColumnName("PROD_ID");
                entity.Property(p => p.name).HasColumnName("PROD_NAME").IsRequired();
                entity.Property(p => p.description).HasColumnName("PROD_DESCRIPTION");
                entity.Property(p => p.price).HasColumnName("PRICE").HasColumnType("DECIMAL(10,2)");
                entity.Property(p => p.logo).HasColumnName("PROD_LOGO");
            });
    }

    public DbSet<ProductType> ProductType { get; set; }
    public DbSet<Product> Product { get; set; }
}