
namespace Biller.Application.Infrastructure.Interface.Persistence.Services;

public interface ITenantDbService
{
    public Task Create(string connectionString);
}
