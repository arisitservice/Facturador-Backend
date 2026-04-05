using Biller.Domain.Entities.Tenant;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Biller.Infrastructure.Persistence.Configurations.TenantDb;

public class CfdiUseConfiguration : IEntityTypeConfiguration<CfdiUse>
{
    public void Configure(EntityTypeBuilder<CfdiUse> builder)
    {
        builder.ToTable("CfdiUses").HasKey(c => c.Id);

        builder.Property(c => c.SatCode).HasMaxLength(10).IsRequired();
        builder.Property(c => c.Description).HasMaxLength(200).IsRequired();
        builder.Property(c => c.Status).HasConversion<string>().HasMaxLength(50);
    }
}
