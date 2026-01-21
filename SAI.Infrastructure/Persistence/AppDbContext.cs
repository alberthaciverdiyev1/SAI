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
            new SearchAttributeOption { Id = Guid.NewGuid(), SearchAttributeId = cityAttrId, Value = "Baku",ValueId = "uydbajs"},
            new SearchAttributeOption { Id = Guid.NewGuid(), SearchAttributeId = cityAttrId, Value = "Ganja",ValueId = "123"},
            new SearchAttributeOption { Id = Guid.NewGuid(), SearchAttributeId = brandAttrId, Value = "Apple",ValueId = "090"},
            new SearchAttributeOption { Id = Guid.NewGuid(), SearchAttributeId = brandAttrId, Value = "Samsung",ValueId = "123" }
        );
        
        //End Seeding Data
    }
}