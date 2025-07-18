using KaleNation.Application.DTOs;
using KaleNation.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace KaleNation.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PaymentController : ControllerBase
{
    private readonly IPaymentService _paymentService;

    public PaymentController(IPaymentService paymentService)
    {
        _paymentService = paymentService;
    }

    /// <summary>
    /// Initiates a payment using M-Pesa.
    /// </summary>
    [HttpPost("mpesa")]
    public async Task<IActionResult> ProcessMpesaPayment([FromBody] CreatePaymentDto dto)
    {
        var payment = await _paymentService.ProcessPaymentAsync(dto);
        return Ok(payment);
    }

    /// <summary>
    /// Gets payment by ID.
    /// </summary>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetPayment(Guid id)
    {
        var result = await _paymentService.GetPaymentByIdAsync(id);
        return Ok(result);
    }
}
