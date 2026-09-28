using FinLedger.Application.DTOs;
using FinLedger.Application.Interfaces;
using FinLedger.Domain.Entities;

namespace FinLedger.Application.Services;

public class AccountService
{
    private readonly IAccountRepository _accountRepository;

    public AccountService(IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository;
    }

    public async Task<Guid> CreateAsync(CreateAccountDto dto)
    {
        if (dto.UserId == Guid.Empty)
            throw new ArgumentException("UserId is required.");

        if (string.IsNullOrWhiteSpace(dto.Name))
            throw new ArgumentException("Account name is required.");
            
        var account = new Account(
            dto.UserId,
            dto.Name,
            dto.Type
        );

        await _accountRepository.AddAsync(account);
        await _accountRepository.SaveChangesAsync();

        return account.Id;
    }

    public async Task<List<Account>> GetByUserIdAsync(Guid userId)
    {
        return await _accountRepository.GetByUserIdAsync(userId);
    }
}