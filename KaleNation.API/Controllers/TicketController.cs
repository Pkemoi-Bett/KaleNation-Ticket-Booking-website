using KaleNation.Application.DTOs;
using KaleNation.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace KaleNation.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TicketController : ControllerBase
{
    private readonly ITicketService _ticketService;

    public TicketController(ITicketService ticketService)
    {
        _ticketService = ticketService;
    }

    /// <summary>
    /// Books a ticket.
    /// </summary>
    [HttpPost("book")]
    public async Task<IActionResult> BookTicket([FromBody] CreateTicketDto dto)
    {
        var ticket = await _ticketService.BookTicketAsync(dto);
        return Ok(ticket);
    }

    /// <summary>
    /// Gets ticket by ID.
    /// </summary>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetTicket(Guid id)
    {
        var ticket = await _ticketService.GetTicketByIdAsync(id);
        return Ok(ticket);
    }

    /// <summary>
    /// Marks ticket as scanned.
    /// </summary>
    [HttpPatch("{id}/scan")]
    public async Task<IActionResult> ScanTicket(Guid id)
    {
        await _ticketService.MarkTicketAsScannedAsync(id);
        return Ok("Ticket scanned successfully.");
    }
}
