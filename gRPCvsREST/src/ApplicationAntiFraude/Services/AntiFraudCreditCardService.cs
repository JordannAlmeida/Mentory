using Domain.Models;
using Domain.httpModels.rest;

namespace ApplicationAntiFraud.Services
{
    public class AntiFraudCreditCardService : IAntiFraudCreditCardService
    {

        public async Task<AntiFraudCreditCard> ValidateAntiFraud(CreditCardAntifraudRequest credit)
        {
            await Task.Delay(500);
            return GetAntiFraudAvaliation(credit);
        }

        private static AntiFraudCreditCard GetAntiFraudAvaliation(CreditCardAntifraudRequest credit)
        {
            AntiFraudCreditCard antiFraudCreditCardResponse =
                new()
                {
                    PercentageOfRiskGatewayA = GetRandomNumber(0.0, 100.0),
                    PercentageOfRiskGatewayB = GetRandomNumber(0.0, 100.0),
                    PercentageOfRiskGatewayC = GetRandomNumber(0.0, 100.0),
                    PercentageOfRiskGatewayD = GetRandomNumber(0.0, 100.0),
                    PercentageOfRiskGatewayE = GetRandomNumber(0.0, 100.0)
                };
            var avarageRisk = (antiFraudCreditCardResponse.PercentageOfRiskGatewayA + antiFraudCreditCardResponse.PercentageOfRiskGatewayB + antiFraudCreditCardResponse.PercentageOfRiskGatewayC +
                               antiFraudCreditCardResponse.PercentageOfRiskGatewayD + antiFraudCreditCardResponse.PercentageOfRiskGatewayE) / 5;
            antiFraudCreditCardResponse.Aproved = avarageRisk > 65.0;
            antiFraudCreditCardResponse.Message = avarageRisk > 65.0 ? "approved" : "fail";
            return antiFraudCreditCardResponse;
        }

        private static float GetRandomNumber(double minimum, double maximum)
        {
            Random random = new();
            return (float)(random.NextDouble() * (maximum - minimum) + minimum);
        }
    }
}
