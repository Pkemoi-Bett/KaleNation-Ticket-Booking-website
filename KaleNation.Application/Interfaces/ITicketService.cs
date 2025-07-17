using KaleNation.Application.DTOs;

namespace KaleNation.Application.Interfaces;

public interface ITicketService
{
    /// <summary>
    /// Books a new ticket for a user for a specified event.
    /// </summary>
    Task<TicketDto> BookTicketAsync(CreateTicketDto createTicketDto);

    /// <summary>
    /// Retrieves ticket details by its unique ID.
    /// </summary>
    Task<TicketDto> GetTicketByIdAsync(Guid ticketId);

    /// <summary>
    /// Marks a ticket as scanned during event entry.
    /// </summary>
    Task MarkTicketAsScannedAsync(Guid ticketId);
}
