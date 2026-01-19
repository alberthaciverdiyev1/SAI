using System.Reflection;
using Microsoft.EntityFrameworkCore;
using SAI.Core.Entities;

namespace SAI.Infrastructure.Persistence;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<SearchAttribute> SearchAttributes { get; set; }
    public DbSet<SearchAttributeOption> SearchAttributeOptions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        
        
        //Begin Seeding Data
        var cityAttrId = Guid.NewGuid();
        var brandAttrId = Guid.NewGuid();

        modelBuilder.Entity<SearchAttribute>().HasData(
            new SearchAttribute { Id = cityAttrId, Key = "City" },
            new SearchAttribute { Id = brandAttrId, Key = "Brand" }
        );

        modelBuilder.Entity<SearchAttributeOption>().HasData(
            new SearchAttributeOption { Id = Guid.NewGuid(), SearchAttributeId = cityAttrId, Value = "Baku" },
            new SearchAttributeOption { Id = Guid.NewGuid(), SearchAttributeId = cityAttrId, Value = "Ganja" },
            new SearchAttributeOption { Id = Guid.NewGuid(), SearchAttributeId = brandAttrId, Value = "Apple" },
            new SearchAttributeOption { Id = Guid.NewGuid(), SearchAttributeId = brandAttrId, Value = "Samsung" }
        );
        
        //End Seeding Data
    }
}