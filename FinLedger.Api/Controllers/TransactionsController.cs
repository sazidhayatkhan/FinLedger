using FinLedger.Application.DTOs;
using FinLedger.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace FinLedger.Api.Controllers;

[ApiController]
[Route("api/transactions")]
public class TransactionsController : ControllerBase
{
    private readonly TransactionService _transactionService;

    public TransactionsController(TransactionService transactionService)
    {
        _transactionService = transactionService;
    }

    [HttpPost("income")]
    public async Task<IActionResult> CreateIncome(
        CreateTransactionDto dto)
    {
        var transactionId =
            await _transactionService.CreateIncomeAsync(dto);

        return Ok(new
        {
            id = transactionId
        });
    }

    [HttpPost("expense")]
    public async Task<IActionResult> CreateExpense(
        CreateTransactionDto dto)
    {
        var transactionId =
            await _transactionService.CreateExpenseAsync(dto);

        return Ok(new
        {
            id = transactionId
        });
    }

    [HttpGet]
    public async Task<IActionResult> GetByAccountId(Guid accountId)
    {
        var transactions =
            await _transactionService.GetByAccountIdAsync(accountId);

        return Ok(transactions);
    }
}