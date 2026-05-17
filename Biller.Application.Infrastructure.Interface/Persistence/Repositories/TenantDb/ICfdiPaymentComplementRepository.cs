using Biller.Domain.Entities.Tenant;

namespace Biller.Application.Infrastructure.Interface.Persistence.Repositories.TenantDb;

public interface ICfdiPaymentComplementRepository
{
    Task AddAsync(CfdiPaymentComplement cfdiPaymentComplement);
}
