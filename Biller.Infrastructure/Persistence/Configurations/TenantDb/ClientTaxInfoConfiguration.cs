using Biller.Domain.Entities.Tenant;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Biller.Infrastructure.Persistence.Configurations.TenantDb;

public class ClientTaxInfoConfiguration : IEntityTypeConfiguration<ClientTaxInfo>
{
    public void Configure(EntityTypeBuilder<ClientTaxInfo> builder)
    {
        builder.ToTable("ClientTaxInfos");

        builder.HasOne(r => r.Client)
            .WithMany(rf => rf.ClientTaxInfos)
            .HasForeignKey(ct => ct.ClientId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
