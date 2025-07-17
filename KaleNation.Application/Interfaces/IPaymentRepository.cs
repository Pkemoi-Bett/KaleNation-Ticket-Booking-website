using KaleNation.Domain.Entities;

namespace KaleNation.Application.Interfaces;

public interface IPaymentRepository
{
    Task AddAsync(Payment payment);
    Task<Payment?> GetByIdAsync(Guid paymentId);
}
