using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SAI.Core.Entities;

namespace SAI.Infrastructure.Persistence.Configurations;

public class SearchAttributeConfiguration : IEntityTypeConfiguration<SearchAttribute>
{
    public void Configure(EntityTypeBuilder<SearchAttribute> builder)
    {
        builder.ToTable("SearchAttributes");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Key).IsRequired().HasMaxLength(255);
        builder.HasMany(x => x.Options).WithOne(x => x.SearchAttribute).HasForeignKey(x => x.AttributeId);
        builder.HasIndex(x => x.Key).IsUnique();
        builder.Property(x => x.CreatedAt).IsRequired();

    }
}