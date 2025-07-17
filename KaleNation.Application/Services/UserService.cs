using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KaleNation.Application.DTOs;
using KaleNation.Application.Interfaces;
using KaleNation.Domain.Entities;

namespace KaleNation.Application.Services;
/// <summary>
/// Service that manages creation and lookup of guest users.
/// </summary>

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
    }

    /// <summary>
    /// Creates a new guest user with limited required info.
    /// </summary>


    public async Task<UserDto> CreateGuestUserAsync(GuestUserDto guestUserDto)
    {
        var user = new User
        {
            Id = Guid.NewGuid(),
            FullName = guestUserDto.FullName,
            Email = guestUserDto.Email,
            PhoneNumber = guestUserDto.PhoneNumber,
            Role = "Attendee"
        };

        await _userRepository.AddAsync(user);

        return new UserDto
        {
            Id = user.Id,
            FullName = user.FullName,
            Email = user.Email,
            PhoneNumber = user.PhoneNumber,
            Role = user.Role
        };
    }

    /// <summary>
    /// Retrieves a user by their unique ID.
    /// </summary>
    /// 
    public async Task<UserDto> GetUserByIdAsync(Guid userId)
    {
        var user = await _userRepository.GetByIdAsync(userId);

        if (user == null)
            throw new Exception("User not found.");

        return new UserDto
        {
            Id = user.Id,
            FullName = user.FullName,
            Email = user.Email,
            PhoneNumber = user.PhoneNumber,
            Role = user.Role
        };
    }
}