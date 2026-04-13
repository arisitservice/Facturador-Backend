using Biller.Domain.Entities.Tenant;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Biller.Infrastructure.Persistence.Configurations.TenantDb;

public class AccountTaxInfoConfiguration : IEntityTypeConfiguration<AccountTaxInfo>
{
    public void Configure(EntityTypeBuilder<AccountTaxInfo> builder)
    {
        builder.ToTable("AccountTaxInfos").HasKey(t => t.Id);

        builder.Property(r => r.TaxAddress).HasMaxLength(500).IsRequired();
        builder.Property(r => r.PostalCode).HasMaxLength(5).IsRequired();
        builder.Property(r => r.BusinessName).HasMaxLength(200).IsRequired();
        builder.Property(r => r.TaxId).HasMaxLength(50).IsRequired();

        builder.Property(u => u.Created);
        builder.Property(u => u.CreatedBy).HasMaxLength(256);
        builder.Property(u => u.LastModified);
        builder.Property(u => u.LastModifiedBy).HasMaxLength(256);

        builder.HasOne(r => r.TaxRegime)
            .WithMany(rf => rf.AccountTaxInfos)
            .HasForeignKey(ct => ct.TaxRegimeId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
