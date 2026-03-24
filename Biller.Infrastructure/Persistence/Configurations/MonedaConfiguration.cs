using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Biller.Domain.Entities;

namespace PostFront.Infrastructure.Persistence.Configurations;

public class MonedaConfiguration : IEntityTypeConfiguration<Moneda>
{
    public void Configure(EntityTypeBuilder<Moneda> builder)
    {
        builder.ToTable("Monedas").HasKey(m => m.Id);

        builder.Property(m => m.ClaveSat).HasMaxLength(10);
        builder.Property(m => m.Descripcion).HasMaxLength(200);
        builder.Property(m => m.Estatus);
    }
}
