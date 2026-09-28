using FinLedger.Application.DTOs;
using FinLedger.Application.Interfaces;
using FinLedger.Domain.Entities;
using FinLedger.Domain.Enums;

namespace FinLedger.Application.Services;

public class TransactionService
{
    private readonly IAccountRepository _accountRepository;
    private readonly ITransactionRepository _transactionRepository;

    public TransactionService(
        IAccountRepository accountRepository,
        ITransactionRepository transactionRepository)
    {
        _accountRepository = accountRepository;
        _transactionRepository = transactionRepository;
    }

    public async Task<Guid> CreateIncomeAsync(CreateTransactionDto dto)
    {
        var account = await _accountRepository.GetByIdAsync(dto.AccountId);

        if (account is null)
            throw new KeyNotFoundException("Account not found.");

        account.AddMoney(dto.Amount);

        var transaction = new Transaction(
            dto.AccountId,
            dto.Amount,
            TransactionType.Income,
            dto.Description
        );

        await _transactionRepository.AddAsync(transaction);
        await _transactionRepository.SaveChangesAsync();

        return transaction.Id;
    }

    public async Task<Guid> CreateExpenseAsync(CreateTransactionDto dto)
    {
        var account = await _accountRepository.GetByIdAsync(dto.AccountId);

        if (account is null)
            throw new KeyNotFoundException("Account not found.");

        account.RemoveMoney(dto.Amount);

        var transaction = new Transaction(
            dto.AccountId,
            dto.Amount,
            TransactionType.Expense,
            dto.Description
        );

        await _transactionRepository.AddAsync(transaction);
        await _transactionRepository.SaveChangesAsync();

        return transaction.Id;
    }

    public async Task<List<Transaction>> GetByAccountIdAsync(Guid accountId)
    {
        return await _transactionRepository
            .GetByAccountIdAsync(accountId);
    }
}