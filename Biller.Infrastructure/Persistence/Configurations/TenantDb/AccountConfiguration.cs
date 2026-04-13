using Biller.Domain.Entities.Tenant;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Biller.Infrastructure.Persistence.Configurations.TenantDb;

public class AccountConfiguration : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {
        builder.ToTable("Account").HasKey(t => t.Id);

        builder.Property(r => r.TenantName).HasMaxLength(500).IsRequired();
        builder.Property(r => r.Company).HasMaxLength(500).IsRequired();
        

        builder.Property(u => u.Created);
        builder.Property(u => u.CreatedBy).HasMaxLength(256);
        builder.Property(u => u.LastModified);
        builder.Property(u => u.LastModifiedBy).HasMaxLength(256);
    }
}
