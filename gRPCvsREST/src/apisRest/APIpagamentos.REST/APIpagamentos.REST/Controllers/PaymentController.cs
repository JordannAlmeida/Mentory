using Domain.Models;
using APIpayments.REST.Services;
using Microsoft.AspNetCore.Mvc;

namespace APIpayments.REST.Controllers
{
    [ApiController]
    [Route("payment/")]
    public class PaymentController : Controller
    {
        private readonly IPaymentService paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            this.paymentService = paymentService;
        }

        [HttpPost]
        [Route("creditCard")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PaymentCreditCardResponse))]
        public async Task<PaymentCreditCardResponse> DoPaymentByCreditCard([FromBody] CreditCard creditCard)
        {
            var response = await paymentService.DoPaymentByCreditCardAsync(creditCard);
            return response;
        }
    }
}
