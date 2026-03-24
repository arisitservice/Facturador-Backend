using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Biller.Domain.Entities;

namespace PostFront.Infrastructure.Persistence.Configurations;

public class UnidadMedidaConfiguration : IEntityTypeConfiguration<UnidadMedida>
{
    public void Configure(EntityTypeBuilder<UnidadMedida> builder)
    {
        builder.ToTable("UnidadesMedida").HasKey(u => u.Id);

        builder.Property(u => u.ClaveSat).HasMaxLength(10);
        builder.Property(u => u.Descripcion).HasMaxLength(200);
        builder.Property(u => u.Estatus);
    }
}
