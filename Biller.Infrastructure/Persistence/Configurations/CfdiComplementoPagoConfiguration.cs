using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Biller.Domain.Entities;

namespace PostFront.Infrastructure.Persistence.Configurations;

public class CfdiComplementoPagoConfiguration : IEntityTypeConfiguration<CfdiComplementoPago>
{
    public void Configure(EntityTypeBuilder<CfdiComplementoPago> builder)
    {
        builder.ToTable("CfdiComplementosPago").HasKey(c => c.Id);

        builder.Property(c => c.TipoCambio).HasPrecision(18, 6);
        builder.Property(c => c.Equivalencia).HasPrecision(18, 6);
        builder.Property(c => c.ImporteSaldoAnterior).HasPrecision(18, 4);
        builder.Property(c => c.ImportePagado).HasPrecision(18, 4);
        builder.Property(c => c.ImportePagadoInsoluto).HasPrecision(18, 4);
        builder.Property(c => c.NumOperacion).HasMaxLength(100);
        builder.Property(c => c.Serie).HasMaxLength(10);

        builder.HasOne(c => c.Cfdi)
            .WithMany(cf => cf.ComplementosPago)
            .HasForeignKey(c => c.IdCfdi)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
