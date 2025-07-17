using KaleNation.Domain.Enums;

namespace KaleNation.Application.DTOs;

public class CreateTicketDto
{
    public Guid EventId { get; set; }
    public Guid UserId { get; set; }
    public TicketType Type { get; set; }
}
