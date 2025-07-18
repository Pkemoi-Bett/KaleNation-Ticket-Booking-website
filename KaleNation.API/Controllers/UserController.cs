using KaleNation.Application.DTOs;
using KaleNation.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace KaleNation.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    /// <summary>
    /// Registers a new user (Admin/Organizer).
    /// </summary>
    [HttpPost("register")]
    public async Task<IActionResult> RegisterUser([FromBody] GuestUserDto guestUserDto)
    {
        await _userService.CreateGuestUserAsync(guestUserDto);
        return Ok("User registered successfully.");
    }

    /// <summary>
    /// Gets a user by ID.
    /// </summary>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetUser(Guid id)
    {
        var user = await _userService.GetUserByIdAsync(id);
        return Ok(user);
    }
}
