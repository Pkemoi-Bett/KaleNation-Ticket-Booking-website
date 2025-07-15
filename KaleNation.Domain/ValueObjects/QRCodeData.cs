namespace KaleNation.Domain.ValueObjects;

public class QRCodeData
{
    public Guid TicketId { get; set; }      // Ticket being encoded
    public Guid UserId { get; set; }        // Owner of the ticket
    public DateTime Expiry { get; set; }    // When this QR code becomes invalid

    public string ToEncodedString()
    {
        return $"{TicketId}:{UserId}:{Expiry:o}";
    }
}
