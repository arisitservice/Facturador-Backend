using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace PostFront.Infrastructure.Persistence.Configurations;

public class EmisorConfiguration : IEntityTypeConfiguration<Biller.Domain.Entities.Emisor>
{
    public void Configure(EntityTypeBuilder<Biller.Domain.Entities.Emisor> builder)
    {
        builder.ToTable("Emisores").HasKey(e => e.Id);

        builder.Property(e => e.Nombre).HasMaxLength(200);
        builder.Property(e => e.RegimenFiscal).HasMaxLength(100);
        builder.Property(e => e.Rfc).HasMaxLength(50);
    }
}
