using Microsoft.AspNetCore.Mvc;
using Domain.Models;
using APIantiFraud.REST.Services;

namespace APIantiFraud.REST.Controllers
{
    [ApiController]
    [Route("payment/")]
    public class AntiFraudPaymentController : Controller
    {
        private readonly IAntiFraudCreditCardService _creditCardService;

        public AntiFraudPaymentController(IAntiFraudCreditCardService creditCardService)
        {
            _creditCardService = creditCardService;
        }

        [HttpPost]
        [Route("creditCard")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AntiFraudCreditCardResponse))]
        public async Task<AntiFraudCreditCardResponse> CallValidateAntiFraudCreditCard([FromBody] CreditCard creditCard)
        {
            var response = await _creditCardService.ValidateAntiFraud(creditCard);
            return response;
        }
    }
}
