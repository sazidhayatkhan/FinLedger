using FinLedger.Application.DTOs;
using FinLedger.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace FinLedger.Api.Controllers;

[ApiController]
[Route("api/accounts")]
public class AccountsController : ControllerBase
{
    private readonly AccountService _accountService;

    public AccountsController(AccountService accountService)
    {
        _accountService = accountService;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateAccountDto dto)
    {
        var accountId = await _accountService.CreateAsync(dto);

        return Ok(new
        {
            id = accountId
        });
    }
}