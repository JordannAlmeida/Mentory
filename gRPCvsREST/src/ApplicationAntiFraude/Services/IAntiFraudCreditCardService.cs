using Domain.Models;
using Domain.httpModels.rest;

namespace ApplicationAntiFraud.Services
{
    public interface IAntiFraudCreditCardService
    {
        Task<AntiFraudCreditCard> ValidateAntiFraud(CreditCardAntifraudRequest credit);
    }
}
