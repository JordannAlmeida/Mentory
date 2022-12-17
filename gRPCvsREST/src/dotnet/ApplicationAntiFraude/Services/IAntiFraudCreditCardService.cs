using Domain.Models;
using Domain.httpModels.rest;

namespace ApplicationAntiFraude.Services
{
    public interface IAntiFraudCreditCardService
    {
        Task<AntiFraudCreditCard> ValidateAntiFraud<T>(T credit);
    }
}
