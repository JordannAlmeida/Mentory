using Domain.httpModels.rest;
using Domain.dtos;
using Domain.httpModels.proto;
using System.Diagnostics;

namespace APIpayments.REST.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<PaymentService> _logger;
        private readonly AntiFraudPayment.AntiFraudPaymentClient _clientRPC;

        public PaymentService(IHttpClientFactory httpClientFactory, AntiFraudPayment.AntiFraudPaymentClient clientRPC, ILogger<PaymentService> logger)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
            _clientRPC = clientRPC;
        }

        public async Task<PaymentCreditCardResponse> DoPaymentByCreditCardAsync(CreditCardAntifraudRequest creditCard)
        {
            try
            {
                var httpClient = _httpClientFactory.CreateClient();
                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();
                using var response = await httpClient.PostAsJsonAsync("https://localhost:8084/payment/creditCard", creditCard);
                stopWatch.Stop();
                TimeSpan ts = stopWatch.Elapsed;
                getMetric(stopWatch.Elapsed, "REST");
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

        public async Task<PaymentCreditCardResponse> DoPaymentByCreditCardGRPC(CreditCardGRPC creditCard)
        {
            try
            {
                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();
                var response = await _clientRPC.CallValidateAntiFraudCreditCardAsync(creditCard);
                stopWatch.Stop();
                TimeSpan ts = stopWatch.Elapsed;
                getMetric(stopWatch.Elapsed, "gRPC");
                if (response != null)
                {
                    return new PaymentCreditCardResponse
                    {
                        Aproved = response.Aproved,
                        MessageNotification = response.Message ?? ""
                    };
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Generic error", ex);
            }
            return new PaymentCreditCardResponse { Aproved = false, MessageNotification = "Error XPTO" };
        }

        private void getMetric(TimeSpan ts, string mode)
        {
            string elapsedTime = string.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                    ts.Hours, ts.Minutes, ts.Seconds,
                    ts.Milliseconds / 10);
            _logger.Log(LogLevel.Information, "RunTime in mode " + mode + ": " + elapsedTime);
        }
    }
}
