using KaleNation.Application.DTOs;
using KaleNation.Application.Interfaces;
using KaleNation.Domain.Entities;
using KaleNation.Domain.Enums;

namespace KaleNation.Application.Services;

public class TicketService : ITicketService
{
    private readonly ITicketRepository _ticketRepository;
    private readonly IEventRepository _eventRepository;

    public TicketService(
        ITicketRepository ticketRepository,
        IEventRepository eventRepository)
    {
        _ticketRepository = ticketRepository;
        _eventRepository = eventRepository;
    }

    /// <summary>
    /// Books a new ticket for a user for a specified event.
    /// </summary>
    public async Task<TicketDto> BookTicketAsync(CreateTicketDto createTicketDto)
    {
        // Retrieves the event to check capacity and details.
        var eventEntity = await _eventRepository.GetByIdAsync(createTicketDto.EventId);

        if (eventEntity == null)
            throw new Exception("Event not found.");

        // Calculate price based on ticket type.
        var price = GetPriceForTicketType(createTicketDto.Type);

        // Create domain Ticket entity.
        var ticket = new Ticket
        {
            Id = Guid.NewGuid(),
            EventId = createTicketDto.EventId,
            UserId = createTicketDto.UserId,
            Type = createTicketDto.Type,
            Price = price,
            IsScanned = false,
            PurchaseDate = DateTime.UtcNow
        };

        await _ticketRepository.AddAsync(ticket);

        // Returns the booked ticket as a DTO for the caller.
        return new TicketDto
        {
            Id = ticket.Id,
            EventId = ticket.EventId,
            UserId = ticket.UserId,
            Type = ticket.Type,
            Price = ticket.Price,
            IsScanned = ticket.IsScanned,
            PurchaseDate = ticket.PurchaseDate
        };
    }

    /// <summary>
    /// Retrieves ticket details by its unique ID.
    /// </summary>
    public async Task<TicketDto> GetTicketByIdAsync(Guid ticketId)
    {
        // Fetches a ticket entity and maps it to a DTO for output.
        var ticket = await _ticketRepository.GetByIdAsync(ticketId);

        if (ticket == null)
            throw new Exception("Ticket not found.");

        return new TicketDto
        {
            Id = ticket.Id,
            EventId = ticket.EventId,
            UserId = ticket.UserId,
            Type = ticket.Type,
            Price = ticket.Price,
            IsScanned = ticket.IsScanned,
            PurchaseDate = ticket.PurchaseDate
        };
    }

    /// <summary>
    /// Marks a ticket as scanned during event entry.
    /// </summary>
    public async Task MarkTicketAsScannedAsync(Guid ticketId)
    {
        // Updates the ticket to reflect that the QR code was scanned at the venue.
        var ticket = await _ticketRepository.GetByIdAsync(ticketId);

        if (ticket == null)
            throw new Exception("Ticket not found.");

        ticket.IsScanned = true;

        await _ticketRepository.UpdateAsync(ticket);
    }

    /// <summary>
    /// Determines the price for the given ticket type.
    /// </summary>
    private decimal GetPriceForTicketType(TicketType type)
    {
        // Returns predefined prices based on ticket category.
        return type switch
        {
            TicketType.REGULAR => 1000,
            TicketType.VIP => 3000,
            TicketType.VVIP => 5000,
            _ => 0
        };
    }
}
