using Domain.Models;

namespace APIpayments.REST.Services
{
    public interface IPaymentService
    {
        Task<PaymentCreditCardResponse> DoPaymentByCreditCardAsync(CreditCard creditCard);
    }
}
