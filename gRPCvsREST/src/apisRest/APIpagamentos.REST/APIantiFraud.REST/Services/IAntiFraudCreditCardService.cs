using Domain.Models;

namespace APIantiFraud.REST.Services
{
    public interface IAntiFraudCreditCardService
    {
        Task<AntiFraudCreditCardResponse> ValidateAntiFraud(CreditCard credit);
    }
}
