using FinLedger.Application.DTOs;
using FinLedger.Application.Interfaces;
using FinLedger.Domain.Entities;

namespace FinLedger.Application.Services;

public class UserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Guid> CreateAsync(CreateUserDto dto)
    {
        var user = new User(
            dto.Name,
            dto.Email
        );

        await _userRepository.AddAsync(user);
        await _userRepository.SaveChangesAsync();

        return user.Id;
    }
}