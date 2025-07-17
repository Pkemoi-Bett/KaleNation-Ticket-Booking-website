namespace KaleNation.Application.DTOs;

public class UserDto
{
    public Guid Id { get; set; }
    public string FullName { get; set; }= "Dancer Mkali";
    public string Email { get; set; } = "admin@gmail.com";
    public string PhoneNumber { get; set; }= "+254712345678";
    public string Role { get; set; }= "Attendee";
}
