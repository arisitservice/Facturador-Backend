using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Biller.Domain.Entities.Tenant;

namespace Biller.Infrastructure.Persistence.Configurations.TenantDb;

public class ClientConfiguration : IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> builder)
    {
        builder.ToTable("Clients").HasKey(t => t.Id);


        builder.Property(r => r.TaxAddress);
        builder.Property(r => r.PostalCode).HasMaxLength(5);
        builder.Property(r => r.Name).HasMaxLength(200);
        builder.Property(r => r.BusinessName).HasMaxLength(200);
        builder.Property(r => r.TaxId).HasMaxLength(50);

        builder.HasOne(r => r.TaxRegime)
            .WithMany(rf => rf.Clients)
            .HasForeignKey(v => v.TaxRegimeId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
