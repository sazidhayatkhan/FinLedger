using FinLedger.Application.Interfaces;
using FinLedger.Domain.Entities;
using FinLedger.Infrastructure.Persistence;

namespace FinLedger.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly FinLedgerDbContext _context;

    public UserRepository(FinLedgerDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(User user)
    {
        await _context.Users.AddAsync(user);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}