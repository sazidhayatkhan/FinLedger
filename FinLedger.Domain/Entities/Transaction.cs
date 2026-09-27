using FinLedger.Domain.Enums;

namespace FinLedger.Domain.Entities;

public class Transaction
{
    public Guid Id { get; private set; }

    public Guid AccountId { get; private set; }

    public decimal Amount { get; private set; }

    public TransactionType Type { get; private set; }

    public string Description { get; private set; }

    public DateTime Date { get; private set; }

    public Transaction(
        Guid accountId,
        decimal amount,
        TransactionType type,
        string description)
    {
        if (amount <= 0)
            throw new ArgumentException("Amount must be greater than zero.");

        Id = Guid.NewGuid();
        AccountId = accountId;
        Amount = amount;
        Type = type;
        Description = description;
        Date = DateTime.UtcNow;
    }
}