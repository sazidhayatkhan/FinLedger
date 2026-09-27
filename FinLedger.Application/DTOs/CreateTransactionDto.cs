namespace FinLedger.Application.DTOs;

public class CreateTransactionDto
{
    public Guid AccountId { get; set; }
    public decimal Amount { get; set; }
    public string Description { get; set; } = string.Empty;
}