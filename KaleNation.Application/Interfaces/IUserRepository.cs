using KaleNation.Domain.Entities;

namespace KaleNation.Application.Interfaces;

/// <summary>
/// Handles persistence and retrieval of User entities.
/// </summary>
public interface IUserRepository
{
    Task AddAsync(User user); // Adds a new user.
    Task<User?> GetByIdAsync(Guid userId); // Retrieves a user by ID.
}
