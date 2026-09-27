using FinLedger.Application.Interfaces;
using FinLedger.Domain.Entities;
using FinLedger.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace FinLedger.Infrastructure.Repositories;

public class AccountRepository : IAccountRepository
{
    private readonly FinLedgerDbContext _context;

    public AccountRepository(FinLedgerDbContext context)
    {
        _context = context;
    }

    public async Task<Account?> GetByIdAsync(Guid id)
    {
        return await _context.Accounts
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<Account>> GetByUserIdAsync(Guid userId)
    {
        return await _context.Accounts
            .Where(x => x.UserId == userId)
            .ToListAsync();
    }

    public async Task AddAsync(Account account)
    {
        await _context.Accounts.AddAsync(account);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}