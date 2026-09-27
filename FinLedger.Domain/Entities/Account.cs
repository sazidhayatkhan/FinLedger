using FinLedger.Domain.Enums;

namespace FinLedger.Domain.Entities;

public class Account
{
    public Guid Id { get; private set; }

    public Guid UserId { get; private set; }

    public string Name { get; private set; }

    public AccountType Type { get; private set; }

    public decimal Balance { get; private set; }

    public DateTime CreatedAt { get; private set; }

    public Account(Guid userId, string name, AccountType type)
    {
        Id = Guid.NewGuid();
        UserId = userId;
        Name = name;
        Type = type;
        Balance = 0;
        CreatedAt = DateTime.UtcNow;
    }

    public void AddMoney(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Amount must be greater than zero.");

        Balance += amount;
    }

    public void RemoveMoney(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Amount must be greater than zero.");

        if (amount > Balance)
            throw new InvalidOperationException("Insufficient balance.");

        Balance -= amount;
    }
}