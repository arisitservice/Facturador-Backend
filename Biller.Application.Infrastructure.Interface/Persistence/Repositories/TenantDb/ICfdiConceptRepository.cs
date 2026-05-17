using Biller.Domain.Entities.Tenant;

namespace Biller.Application.Infrastructure.Interface.Persistence.Repositories.TenantDb;

public interface ICfdiConceptRepository
{
    Task AddAsync(CfdiConcept cfdiConcept);
}
