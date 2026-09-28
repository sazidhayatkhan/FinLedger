using FinLedger.Domain.Entities;
using FinLedger.Domain.Enums;

namespace FinLedger.Domain.Tests;

public class AccountTests
{
    [Fact]
    public void AddMoney_ShouldIncreaseBalance()
    {
        var account = new Account(
            Guid.NewGuid(),
            "My Bank",
            AccountType.Bank
        );

        account.AddMoney(5000);

        Assert.Equal(5000, account.Balance);
    }

    [Fact]
    public void RemoveMoney_ShouldDecreaseBalance()
    {
        var account = new Account(
            Guid.NewGuid(),
            "My Bank",
            AccountType.Bank
        );

        account.AddMoney(5000);

        account.RemoveMoney(2000);

        Assert.Equal(3000, account.Balance);
    }

    [Fact]
    public void RemoveMoney_ShouldThrow_WhenBalanceIsInsufficient()
    {
        var account = new Account(
            Guid.NewGuid(),
            "My Bank",
            AccountType.Bank
        );

        account.AddMoney(1000);

        Assert.Throws<InvalidOperationException>(
            () => account.RemoveMoney(2000)
        );
    }

    [Fact]
    public void AddMoney_ShouldThrow_WhenAmountIsZeroOrNegative()
    {
        var account = new Account(
            Guid.NewGuid(),
            "My Bank",
            AccountType.Bank
        );

        Assert.Throws<ArgumentException>(
            () => account.AddMoney(0)
        );
    }
}