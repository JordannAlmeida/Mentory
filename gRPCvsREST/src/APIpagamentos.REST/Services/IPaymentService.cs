using Domain.httpModels.rest;

namespace APIpayments.REST.Services
{
    public interface IPaymentService
    {
        Task<PaymentCreditCardResponse> DoPaymentByCreditCardAsync(CreditCardAntifraudRequest creditCard);
    }
}
