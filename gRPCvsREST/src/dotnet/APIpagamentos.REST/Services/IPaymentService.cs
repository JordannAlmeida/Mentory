using Domain.httpModels.rest;
using Domain.httpModels.proto;

namespace APIpayments.REST.Services
{
    public interface IPaymentService
    {
        Task<PaymentCreditCardResponse> DoPaymentByCreditCardAsync(CreditCardAntifraudRequest creditCard);
        Task<PaymentCreditCardResponse> DoPaymentByCreditCardGRPC(CreditCardGRPC creditCard);
    }
}
