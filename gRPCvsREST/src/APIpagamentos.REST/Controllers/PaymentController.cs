using Domain.httpModels.rest;
using Domain.dtos;
using AutoMapper;
using APIpayments.REST.Services;
using Microsoft.AspNetCore.Mvc;

namespace APIpayments.REST.Controllers
{
    [ApiController]
    [Route("payment/")]
    public class PaymentController : Controller
    {
        private readonly IPaymentService _paymentService;
        private readonly IMapper _mapper;

        public PaymentController(IPaymentService paymentService, IMapper mapper)
        {
            _paymentService = paymentService;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("creditCard")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PaymentCreditCardResponse))]
        public async Task<PaymentCreditCardResponse> DoPaymentByCreditCard([FromBody] CreditCardDTO creditCard)
        {
            var creditCardModel = _mapper.Map<CreditCardAntifraudRequest>(creditCard);
            var response = await _paymentService.DoPaymentByCreditCardAsync(creditCardModel);
            return response;
        }
    }
}
