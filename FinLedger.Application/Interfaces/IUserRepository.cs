using FinLedger.Domain.Entities;

namespace FinLedger.Application.Interfaces;

public interface IUserRepository
{
    Task AddAsync(User user);
    Task SaveChangesAsync();
}