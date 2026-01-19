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
    }
}