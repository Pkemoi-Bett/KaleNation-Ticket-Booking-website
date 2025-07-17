using KaleNation.Application.DTOs;
using KaleNation.Application.Interfaces;
using KaleNation.Domain.Entities;
using KaleNation.Domain.Enums;

namespace KaleNation.Application.Services;

public class PaymentService : IPaymentService
{
    private readonly IPaymentRepository _paymentRepository;
    private readonly IMpesaClient _mpesaClient;

    public PaymentService(IPaymentRepository paymentRepository, IMpesaClient mpesaClient)
    {
        _paymentRepository = paymentRepository;
        _mpesaClient = mpesaClient;
    }

    /// <summary>
    /// Processes payment using selected provider (M-Pesa).
    /// </summary>
    public async Task<PaymentDto> ProcessPaymentAsync(CreatePaymentDto dto)
    {
        // Send M-Pesa request
        var result = await _mpesaClient.InitiateStkPushAsync(dto.PhoneNumber, dto.Amount);

        var payment = new Payment
        {
            Id = Guid.NewGuid(),
            TicketId = dto.TicketId,
            Amount = dto.Amount,
            Provider = dto.Provider,
            Status = result ? PaymentStatus.Completed : PaymentStatus.Failed,
            PaymentDate = DateTime.UtcNow
        };

        await _paymentRepository.AddAsync(payment);

        return new PaymentDto
        {
            Id = payment.Id,
            TicketId = payment.TicketId,
            Amount = payment.Amount,
            Provider = payment.Provider,
            Status = payment.Status.ToString(),
            PaymentDate = payment.PaymentDate,
            PhoneNumber = dto.PhoneNumber
        };
    }

    /// <summary>
    /// Returns a payment record by its ID.
    /// </summary>
    public async Task<PaymentDto> GetPaymentByIdAsync(Guid paymentId)
    {
        var payment = await _paymentRepository.GetByIdAsync(paymentId)
                      ?? throw new Exception("Payment not found");

        return new PaymentDto
        {
            Id = payment.Id,
            TicketId = payment.TicketId,
            Amount = payment.Amount,
            Provider = payment.Provider,
            Status = payment.Status.ToString(),
            PaymentDate = payment.PaymentDate
        };
    }
}
