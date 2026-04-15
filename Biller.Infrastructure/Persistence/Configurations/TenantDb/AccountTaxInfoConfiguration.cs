using Biller.Domain.Entities.Tenant;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Biller.Infrastructure.Persistence.Configurations.TenantDb;

public class AccountTaxInfoConfiguration : IEntityTypeConfiguration<AccountTaxInfo>
{
    public void Configure(EntityTypeBuilder<AccountTaxInfo> builder)
    {
        builder.ToTable("AccountTaxInfos");
    }
}
