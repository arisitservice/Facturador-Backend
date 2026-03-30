using Biller.Domain.Entities.MainDb;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Biller.Infrastructure.Persistence.Configurations.MainDb;

public class TenantConfiguration : IEntityTypeConfiguration<Tenant>
{
    public void Configure(EntityTypeBuilder<Tenant> builder)
    {
        builder.ToTable("Tenants").HasKey(t => t.Id);

        builder.Property(t => t.Name).HasMaxLength(200);
        builder.Property(t => t.Company).HasMaxLength(200);
        builder.Property(t => t.Email).HasMaxLength(256);
        builder.Property(t => t.Subdomain).HasMaxLength(100);
        builder.Property(t => t.ConnectionString).HasMaxLength(500);
    }
}
