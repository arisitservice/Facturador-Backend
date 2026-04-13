using Biller.Domain.Entities.Tenant;

namespace Biller.Application.Infrastructure.Interface.Persistence.Repositories.TenantDb;

public interface IClientTaxInfoRepository
{
    Task<ClientTaxInfo?> GetByIdAsync(int id);
    Task<IEnumerable<ClientTaxInfo>> GetAllByClientIdAsync(int clientId);
    Task AddAsync(ClientTaxInfo clientTaxInfo);
    Task UpdateAsync(ClientTaxInfo clientTaxInfo);
    Task DeleteAsync(int id);
}
