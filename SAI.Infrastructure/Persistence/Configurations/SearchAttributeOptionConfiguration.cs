using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SAI.Core.Entities;

namespace SAI.Infrastructure.Persistence.Configurations;

public class SearchAttributeOptionConfiguration:IEntityTypeConfiguration<SearchAttributeOption>
{
    public void Configure(EntityTypeBuilder<SearchAttributeOption> builder)
    {
        builder.ToTable("SearchAttributeOptions");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Value).IsRequired().HasMaxLength(255);
        builder.Property(x => x.ValueId).IsRequired().HasMaxLength(255);
        builder.HasOne(x => x.SearchAttribute).WithMany(x => x.Options).HasForeignKey(x => x.SearchAttributeId);
        builder.Property(x => x.CreatedAt).IsRequired();
    }
}