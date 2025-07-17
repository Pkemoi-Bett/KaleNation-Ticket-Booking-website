namespace KaleNation.Application.DTOs;

public class PaymentDto
{
    public Guid Id { get; set; }
    public Guid TicketId { get; set; }
    public decimal Amount { get; set; }
    public string Provider { get; set; } = "MPesa";
    public string PhoneNumber { get; set; } = "+2547XXXXXXXX"; 
    public string Status { get; set; } = "Pending";
    public DateTime PaymentDate { get; set; }
}
