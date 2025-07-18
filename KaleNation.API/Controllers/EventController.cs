using KaleNation.Application.DTOs;
using KaleNation.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace KaleNation.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EventController : ControllerBase
{
    private readonly IEventService _eventService;

    public EventController(IEventService eventService)
    {
        _eventService = eventService;
    }

    /// <summary>
    /// Creates a new event.
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> CreateEvent([FromBody] EventDto dto)
    {
        await _eventService.CreateEventAsync(dto);
        return Ok("Event created successfully.");
    }

    /// <summary>
    /// Retrieves a list of events by filter.
    /// </summary>
    [HttpGet]
    public async Task<IActionResult> GetEvents([FromQuery] string? genre, [FromQuery] string? location, [FromQuery] DateTime? date)
    {
        var result = await _eventService.GetEventsAsync(genre, location, date);
        return Ok(result);
    }
}
