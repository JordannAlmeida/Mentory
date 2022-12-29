using Microsoft.AspNetCore.Mvc;
using Domain.httpModels.rest;
using Domain.Models;
using Domain.dtos;
using AutoMapper;
using ApplicationAntiFraude.Services;

namespace APIantiFraud.REST.Controllers
{
    [ApiController]
    [Route("payment/")]
    public class AntiFraudPaymentController : Controller
    {
        private readonly IAntiFraudCreditCardService _creditCardService;
        private readonly IMapper _mapper;

        public AntiFraudPaymentController(IAntiFraudCreditCardService creditCardService, IMapper mapper)
        {
            _creditCardService = creditCardService;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("creditCard")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AntiFraudCreditCard))]
        public async Task<AntiFraudCreditCardDTO> CallValidateAntiFraudCreditCard([FromBody] CreditCardAntifraudRequest creditCard)
        {
            var resultService = await _creditCardService.ValidateAntiFraud(creditCard);
            return _mapper.Map<AntiFraudCreditCardDTO>(resultService);
        }
    }
}
