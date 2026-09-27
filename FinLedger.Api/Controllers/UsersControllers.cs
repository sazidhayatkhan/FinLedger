using FinLedger.Application.DTOs;
using FinLedger.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace FinLedger.Api.Controllers;

[ApiController]
[Route("api/users")]
public class UsersController : ControllerBase
{
    private readonly UserService _userService;

    public UsersController(UserService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateUserDto dto)
    {
        var userId = await _userService.CreateAsync(dto);

        return Ok(new
        {
            id = userId
        });
    }
}