using FinLedger.Domain.Enums;

namespace FinLedger.Application.DTOs;

public class CreateAccountDto
{
    public Guid UserId { get; set; }

    public string Name { get; set; } = string.Empty;

    public AccountType Type { get; set; }
}