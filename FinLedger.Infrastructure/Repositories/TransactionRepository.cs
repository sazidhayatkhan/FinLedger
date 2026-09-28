using FinLedger.Application.Interfaces;
using FinLedger.Domain.Entities;
using FinLedger.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace FinLedger.Infrastructure.Repositories;

public class TransactionRepository : ITransactionRepository
{
    private readonly FinLedgerDbContext _context;

    public TransactionRepository(FinLedgerDbContext context)
    {
        _context = context;
    }

    public async Task<List<Transaction>> GetByAccountIdAsync(Guid accountId)
    {
        return await _context.Transactions
            .Where(x => x.AccountId == accountId)
            .OrderByDescending(x => x.Date)
            .ToListAsync();
    }
    public async Task AddAsync(Transaction transaction)
    {
        await _context.Transactions.AddAsync(transaction);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}