using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Biller.Domain.Entities.Tenant;

namespace Biller.Infrastructure.Persistence.Configurations.TenantDb;

public class ClientConfiguration : IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> builder)
    {
        builder.ToTable("Clients").HasKey(t => t.Id);

        builder.Property(r => r.Name).HasMaxLength(200).IsRequired();
        builder.Property(u => u.Created);
        builder.Property(u => u.CreatedBy).HasMaxLength(256);
        builder.Property(u => u.LastModified);
        builder.Property(u => u.LastModifiedBy).HasMaxLength(256);
    }
}
