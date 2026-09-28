using FinLedger.Application.Interfaces;
using FinLedger.Domain.Entities;
using FinLedger.Infrastructure.Persistence;

namespace FinLedger.Infrastructure.Repositories;

public class TransactionRepository : ITransactionRepository
{
    private readonly FinLedgerDbContext _context;

    public TransactionRepository(FinLedgerDbContext context)
    {
        _context = context;
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