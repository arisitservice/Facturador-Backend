using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Biller.Domain.Entities;

namespace PostFront.Infrastructure.Persistence.Configurations;

public class RegimenFiscalConfiguration : IEntityTypeConfiguration<RegimenFiscal>
{
    public void Configure(EntityTypeBuilder<RegimenFiscal> builder)
    {
        builder.ToTable("RegimenesFiscales").HasKey(r => r.Id);

        builder.Property(r => r.ClaveSat);
        builder.Property(r => r.Descripcion).HasMaxLength(200);
        builder.Property(r => r.Estatus);
    }
}
