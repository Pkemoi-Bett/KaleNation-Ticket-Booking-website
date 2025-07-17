using KaleNation.Application.DTOs;
using KaleNation.Application.Interfaces;
using KaleNation.Domain.Entities;

namespace KaleNation.Application.Services;

public class EventService : IEventService
{
    private readonly IEventRepository _eventRepository;

    public EventService(IEventRepository eventRepository)
    {
        _eventRepository = eventRepository;
    }

    /// <summary>
    /// Creates a new event from details provided by the organizer.
    /// </summary>
    public async Task CreateEventAsync(EventDto eventDto)
    {
        // Maps the EventDto to a Domain Entity and saves it via the repository.
        var eventEntity = new Event
        {
            Id = Guid.NewGuid(),
            Title = eventDto.Title,
            Description = eventDto.Description,
            Genre = eventDto.Genre,
            Location = eventDto.Location,
            Date = eventDto.Date,
            Capacity = eventDto.Capacity,
            OrganizerId = eventDto.OrganizerId
        };

        await _eventRepository.AddAsync(eventEntity);
    }

    /// <summary>
    /// Retrieves all upcoming events filtered by optional criteria.
    /// </summary>
    public async Task<List<EventDto>> GetEventsAsync(string genre, string location, DateTime? date)
    {
        // Retrieves events matching filters and maps them to DTOs for presentation.
        var events = await _eventRepository.GetFilteredEventsAsync(genre, location, date);

        return events.Select(e => new EventDto
        {
            Id = e.Id,
            Title = e.Title,
            Description = e.Description,
            Genre = e.Genre,
            Location = e.Location,
            Date = e.Date,
            Capacity = e.Capacity,
            OrganizerId = e.OrganizerId
        }).ToList();
    }
}
