
using KaleNation.Application.DTOs;

namespace KaleNation.Application.Interfaces;

public interface IPaymentService
{
    /// <summary>
    /// Initiates a payment process using the given provider.
    /// </summary>
    Task<PaymentDto> ProcessPaymentAsync(CreatePaymentDto dto);

    /// <summary>
    /// Retrieves payment details by ID.
    /// </summary>
    Task<PaymentDto> GetPaymentByIdAsync(Guid paymentId);
}
