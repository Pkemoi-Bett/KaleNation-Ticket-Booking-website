namespace KaleNation.Application.DTOs;

public class EventDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }= "KaleNation Event";
    public string Description { get; set; }= "Sherehe sheria";
    public string Genre { get; set; }= "Benga";
    public string Location { get; set; }= "Tamasha";
    public DateTime Date { get; set; }
    public int Capacity { get; set; }
    public Guid OrganizerId { get; set; }
}
