using KaleNation.Application.DTOs;

namespace KaleNation.Application.Interfaces;

public interface IEventService
{
    /// <summary>
    /// Creates a new event.
    /// </summary>
    Task CreateEventAsync(EventDto eventDto);

    /// <summary>
    /// Gets all events based on filters.
    /// </summary>
    Task<List<EventDto>> GetEventsAsync(string genre, string location, DateTime? date);
}
