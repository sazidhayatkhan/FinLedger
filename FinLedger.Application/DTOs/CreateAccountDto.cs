using System.ComponentModel.DataAnnotations;
using FinLedger.Domain.Enums;

namespace FinLedger.Application.DTOs;

public class CreateAccountDto
{
    [Required]
    public Guid UserId { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    [Required]
    public AccountType Type { get; set; }
}