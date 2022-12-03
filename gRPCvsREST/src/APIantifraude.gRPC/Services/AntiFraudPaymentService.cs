using Domain.httpModels.proto;
using ApplicationAntiFraud.Services;
using AutoMapper;
using Domain.httpModels.rest;

namespace APIantifraude.gRPC.Services
{
    public class AntiFraudPaymentService : AntiFraudPayment.AntiFraudPaymentBase
    {
        private readonly IAntiFraudCreditCardService _antiFraudCreditCardService;
        private readonly IMapper _mapper;

        public AntiFraudPaymentService(IAntiFraudCreditCardService antiFraudCreditCardService, IMapper mapper)
        {
            _antiFraudCreditCardService = antiFraudCreditCardService;
            _mapper = mapper;
        }

        public async Task<AntiFraudResponseGRPC> CallValidateAntiFraudCreditCard(CreditCardGRPC creditCardGRPC)
        {
            var creditCard = _mapper.Map<CreditCardAntifraudRequest>(creditCardGRPC);
            var resultService = await _antiFraudCreditCardService.ValidateAntiFraud(creditCard);
            return _mapper.Map<AntiFraudResponseGRPC>(resultService);
        }
    }
}
