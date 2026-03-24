using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Biller.Domain.Entities;

namespace PostFront.Infrastructure.Persistence.Configurations;

public class CfdiConfiguration : IEntityTypeConfiguration<Cfdi>
{
    public void Configure(EntityTypeBuilder<Cfdi> builder)
    {
        builder.ToTable("Cfdis").HasKey(c => c.Id);

        builder.Property(c => c.UUID).HasMaxLength(36);
        builder.Property(c => c.TipoCambio).HasPrecision(18, 6);
        builder.Property(c => c.Notas).HasMaxLength(500);

        builder.HasOne(c => c.Receptor)
            .WithMany(r => r.Cfdis)
            .HasForeignKey(c => c.IdReceptor)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(c => c.Emisor)
            .WithMany(e => e.Cfdis)
            .HasForeignKey(c => c.IdEmisor)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
