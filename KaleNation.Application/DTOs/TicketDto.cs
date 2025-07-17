using KaleNation.Domain.Enums;

namespace KaleNation.Application.DTOs;

public class TicketDto
{
    public Guid Id { get; set; }
    public Guid EventId { get; set; }
    public Guid UserId { get; set; }
    public TicketType Type { get; set; }
    public decimal Price { get; set; }
    public bool IsScanned { get; set; }
    public DateTime PurchaseDate { get; set; }
}
