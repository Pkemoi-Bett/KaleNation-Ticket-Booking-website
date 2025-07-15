

namespace KaleNation.Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;


        //Navigation property : tickets this user has purchased 
        public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
    }
}



