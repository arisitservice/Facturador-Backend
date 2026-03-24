namespace Biller.Application.Infrastructure.Interface.Persistence.Repositories;

public interface IReceptorRepository
{
    Task<Biller.Domain.Entities.Receptor?> GetByIdAsync(int id);
    Task<IEnumerable<Biller.Domain.Entities.Receptor>> GetAllAsync();
    Task AddAsync(Biller.Domain.Entities.Receptor receptor);
    Task UpdateAsync(Biller.Domain.Entities.Receptor receptor);
    Task DeleteAsync(int id);
}
