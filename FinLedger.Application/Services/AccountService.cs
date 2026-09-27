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
        var account = new Account(
            dto.UserId,
            dto.Name,
            dto.Type
        );

        await _accountRepository.AddAsync(account);
        await _accountRepository.SaveChangesAsync();

        return account.Id;
    }
}