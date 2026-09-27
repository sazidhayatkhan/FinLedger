using FinLedger.Domain.Entities;

namespace FinLedger.Application.Interfaces;

public interface IAccountRepository
{
    Task<Account?> GetByIdAsync(Guid id);

    Task<List<Account>> GetByUserIdAsync(Guid userId);

    Task AddAsync(Account account);

    Task SaveChangesAsync();
}