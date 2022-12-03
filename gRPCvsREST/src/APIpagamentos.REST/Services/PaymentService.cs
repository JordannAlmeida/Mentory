using Domain.httpModels.rest;
using Domain.dtos;

namespace APIpayments.REST.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<PaymentService> _logger;

        public PaymentService(IHttpClientFactory httpClientFactory, ILogger<PaymentService> logger)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }

        public async Task<PaymentCreditCardResponse> DoPaymentByCreditCardAsync(CreditCardAntifraudRequest creditCard)
        {
            try
            {
                var httpClient = _httpClientFactory.CreateClient();
                using var response = await httpClient.PostAsJsonAsync("https://localhost:8084/payment/creditCard", creditCard);
                if (response.IsSuccessStatusCode)
                {
                    var antiFraudCreditCardResponse = await response.Content.ReadAsAsync<AntiFraudCreditCardDTO>();
                    return new PaymentCreditCardResponse
                    {
                        Aproved = antiFraudCreditCardResponse != null ? antiFraudCreditCardResponse.Aproved : false,
                        MessageNotification = antiFraudCreditCardResponse != null && antiFraudCreditCardResponse.Message != null ? antiFraudCreditCardResponse.Message : ""
                    };
                }

            } catch (Exception ex)
            {
                _logger.LogError("Generic error", ex);
            }
            return new PaymentCreditCardResponse { Aproved = false, MessageNotification = "Error XPTO" };
        }
    }
}
