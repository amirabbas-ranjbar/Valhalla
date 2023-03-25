using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Valhalla.Domain.Partner;

namespace Valhalla.Infrastructure;

public class PartnerEntityTypeConfiguration : IEntityTypeConfiguration<Partners>
{
    public void Configure(EntityTypeBuilder<Partners> builder)
    {
        builder.ToTable(nameof(Partners));

        builder.Property(e => e.Id).HasColumnName("Id");

        builder.HasIndex(e => e.PartnerName, "PARAM_NAME_UNIQUE")
            .IsUnique();
        builder.Property(e => e.PartnerName)
            .IsRequired()
            .HasMaxLength(50)
            .IsUnicode(false);
    }
}