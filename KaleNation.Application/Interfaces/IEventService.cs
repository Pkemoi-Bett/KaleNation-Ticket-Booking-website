using KaleNation.Application.DTOs;

namespace KaleNation.Application.Interfaces;

public interface IEventService
{
    //Creates a new Event from details provided by an organizer
    Task CreateEvebtAsync(EventDto eventDto);

    //Retrieves all upcoming events filtered by optional criteria 

    Task<List<EventDto>> GetEventAsync(
        string genre,
        string location,
        DateTime? startDate
    );
    

}