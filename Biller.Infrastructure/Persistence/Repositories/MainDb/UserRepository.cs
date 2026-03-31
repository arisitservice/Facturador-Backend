using Biller.Application.Infrastructure.Interface.Persistence.Repositories.MainDb;
using Biller.Domain.Entities.Main;
using Biller.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Biller.Infrastructure.Persistence.Repositories.MainDb;

public class UserRepository : IUserRepository
{
    private readonly MainDbContext _context;

    public UserRepository(MainDbContext context)
    {
        _context = context;
    }

    public async Task<User?> GetByIdAsync(int id)
    {
        return await _context.Users.FindAsync(id);
    }

    public async Task<User?> GetByEmailAsync(string email)
    {
        return await _context.Users
            .FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task AddAsync(User user)
    {
        await _context.Users.AddAsync(user);
    }

    public async Task UpdateAsync(User user)
    {
        _context.Users.Update(user);
        await Task.CompletedTask;
    }

    public async Task DeleteAsync(int id)
    {
        var user = await _context.Users.FindAsync(id);
        if (user is not null)
            _context.Users.Remove(user);
    }
}
