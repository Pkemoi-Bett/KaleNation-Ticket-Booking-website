using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KaleNation.Application.DTOs
{
    public class CreatePaymentDto
    {
    public Guid TicketId { get; set; }
    public decimal Amount { get; set; }
    public string Provider { get; set; } = "MPesa"; 
    public string PhoneNumber { get; set; } = "+2547XXXXXXXX";
    }
}