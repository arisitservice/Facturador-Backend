using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Biller.Domain.Entities;

namespace PostFront.Infrastructure.Persistence.Configurations;

public class CfdiConceptoConfiguration : IEntityTypeConfiguration<CfdiConcepto>
{
    public void Configure(EntityTypeBuilder<CfdiConcepto> builder)
    {
        builder.ToTable("CfdiConceptos").HasKey(c => c.Id);

        builder.Property(c => c.Descripcion).HasMaxLength(500);
        builder.Property(c => c.Cantidad).HasPrecision(18, 4);
        builder.Property(c => c.ValorUnitario).HasPrecision(18, 4);
        builder.Property(c => c.Importe).HasPrecision(18, 4);
        builder.Property(c => c.TrasladoIva).HasPrecision(18, 4);

        builder.HasOne(c => c.Cfdi)
            .WithMany(cf => cf.Conceptos)
            .HasForeignKey(c => c.IdCfdi)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
