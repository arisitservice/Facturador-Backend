using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Biller.Domain.Entities;

namespace PostFront.Infrastructure.Persistence.Configurations;

public class ProductoConfiguration : IEntityTypeConfiguration<Producto>
{
    public void Configure(EntityTypeBuilder<Producto> builder)
    {
        builder.ToTable("Productos").HasKey(p => p.Id);

        builder.Property(p => p.ClaveSat).HasMaxLength(10);
        builder.Property(p => p.Descripcion).HasMaxLength(200);
        builder.Property(p => p.Estatus);
    }
}
