using System.ComponentModel.DataAnnotations;

namespace FinLedger.Application.DTOs;

public class CreateTransactionDto
{
    [Required]
    public Guid AccountId { get; set; }

    [Range(0.01, double.MaxValue)]
    public decimal Amount { get; set; }

    [MaxLength(500)]
    public string Description { get; set; } = string.Empty;
}