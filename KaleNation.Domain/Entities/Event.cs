

namespace KaleNation.Domain.Entities
{
    public class Event
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public int Capacity { get; set; }
        public Guid OrganizerId { get; set; }

        //Navigation Property
        public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
        
    }
}
