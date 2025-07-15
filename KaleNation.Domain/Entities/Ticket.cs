using System;
using KaleNation.Domain.Enums;


namespace KaleNation.Domain.Entities
{
    public class Ticket
    {
        public Guid Id { get; set; }
        public Guid EventId { get; set; }
        public Guid UserId { get; set; }
        public TicketType Type { get; set; }
        public decimal Price { get; set; }
        public bool IsScanned { get; set; } = false;
        public DateTime PurchaseDate { get; set; }



        // Relationships(Optional Navigation properties)

        public Event? Event { get; set; }
        public User? User { get; set; }
    }

}
