using KaleNation.Domain.Enums;

namespace KaleNation.Domain.Entities
{
    public class Payment
    {
        public Guid Id { get; set; }
        public Guid TicketId { get; set; }                 // Ticket being paid for
        public decimal Amount { get; set; }
        public string Provider { get; set; } = String.Empty;               // Stripe, PayPal, MPesa
        public PaymentStatus Status { get; set; }          // Pending, Completed, Failed
        public DateTime PaymentDate { get; set; }

        public Ticket Ticket { get; set; }= null!; 

    }
}