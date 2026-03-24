using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Biller.Domain.Entities;

namespace PostFront.Infrastructure.Persistence.Configurations;

public class UsoCfdiConfiguration : IEntityTypeConfiguration<UsoCfdi>
{
    public void Configure(EntityTypeBuilder<UsoCfdi> builder)
    {
        builder.ToTable("UsosCfdi").HasKey(u => u.Id);

        builder.Property(u => u.ClaveSat).HasMaxLength(10);
        builder.Property(u => u.Descripcion).HasMaxLength(200);
        builder.Property(u => u.Estatus);
    }
}
