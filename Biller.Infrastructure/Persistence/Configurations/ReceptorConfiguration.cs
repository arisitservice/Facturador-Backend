using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Biller.Domain.Entities;

namespace PostFront.Infrastructure.Persistence.Configurations;

public class ReceptorConfiguration : IEntityTypeConfiguration<Biller.Domain.Entities.Receptor>
{
    public void Configure(EntityTypeBuilder<Biller.Domain.Entities.Receptor> builder)
    {
        builder.ToTable("Receptores").HasKey(t => t.Id);


        builder.Property(r => r.DomicilioFiscal);
        builder.Property(r => r.CodigoPostal).HasMaxLength(5);
        builder.Property(r => r.Nombre).HasMaxLength(200);
        builder.Property(r => r.RazonSocial).HasMaxLength(200);
        builder.Property(r => r.Rfc).HasMaxLength(50);

        builder.HasOne(r => r.RegimenFiscal)
            .WithMany(rf => rf.Receptores)
            .HasForeignKey(v => v.IdRegimenFiscal)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(r => r.UsoCfdi)
            .WithMany(r => r.Receptores)
            .HasForeignKey(v => v.IdUsoCfdi)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
