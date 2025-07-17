using KaleNation.Domain.Entities;

namespace KaleNation.Application.Interfaces;

public interface ITicketRepository
{
    /// <summary>
    /// Adds a new ticket to the system.
    /// </summary>
    Task AddAsync(Ticket ticket);

    /// <summary>
    /// Retrieves a ticket by its unique ID.
    /// </summary>
    Task<Ticket> GetByIdAsync(Guid ticketId);

    /// <summary>
    /// Updates an existing ticket in the data store.
    /// </summary>
    Task UpdateAsync(Ticket ticket);
}
