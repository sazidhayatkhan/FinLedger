using FinLedger.Domain.Entities;

namespace FinLedger.Application.Interfaces;

public interface ITransactionRepository
{
    Task AddAsync(Transaction transaction);
    Task SaveChangesAsync();

    Task<List<Transaction>> GetByAccountIdAsync(Guid accountId);
}