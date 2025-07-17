using KaleNation.Domain.Entities;

namespace KaleNation.Application.Interfaces;

public interface IEventRepository
{
    /// <summary>
    /// Adds a new event to the system.
    /// </summary>
    Task AddAsync(Event eventEntity);

    /// <summary>
    /// Gets filtered events based on optional parameters.
    /// </summary>
    Task<List<Event>> GetFilteredEventsAsync(string genre, string location, DateTime? date);

    /// <summary>
    /// Retrieves a single event by its ID.
    /// </summary>
    Task<Event?> GetByIdAsync(Guid eventId);
}
