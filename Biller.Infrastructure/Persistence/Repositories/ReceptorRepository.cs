using Biller.Application.Infrastructure.Interface.Persistence.Repositories;
using Biller.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Biller.Infrastructure.Persistence.Repositories;

public class ReceptorRepository : IReceptorRepository
{
    private readonly ApplicationDbContext _context;

    public ReceptorRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Biller.Domain.Entities.Receptor?> GetByIdAsync(int id)
    {
        return await _context.Receptores.FindAsync(id);
    }

    public async Task<IEnumerable<Biller.Domain.Entities.Receptor>> GetAllAsync()
    {
        return await _context.Receptores.ToListAsync();
    }

    public async Task AddAsync(Biller.Domain.Entities.Receptor receptor)
    {
        await _context.Receptores.AddAsync(receptor);
    }

    public async Task UpdateAsync(Biller.Domain.Entities.Receptor receptor)
    {
        _context.Receptores.Update(receptor);
        await Task.CompletedTask;
    }

    public async Task DeleteAsync(int id)
    {
        var receptor = await _context.Receptores.FindAsync(id);
        if (receptor is not null)
            _context.Receptores.Remove(receptor);
    }
}
