using KaleNation.Application.DTOs;

namespace KaleNation.Application.Interfaces;

/// <summary>
/// Application logic for handling user-related actions.
/// </summary>
public interface IUserService
{
    Task<UserDto> CreateGuestUserAsync(GuestUserDto guestUserDto); // Creates a guest user.
    Task<UserDto> GetUserByIdAsync(Guid userId); // Retrieves user details by ID.
}
