using Domain.httpModels.proto;
using ApplicationAntiFraud.Services;
using AutoMapper;
using Domain.httpModels.rest;
using Grpc.Core;

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

        override public async Task<AntiFraudResponseGRPC> CallValidateAntiFraudCreditCard(CreditCardGRPC creditCardGRPC, ServerCallContext context)
        {
            var resultService = await _antiFraudCreditCardService.ValidateAntiFraud(creditCardGRPC);
            return _mapper.Map<AntiFraudResponseGRPC>(resultService);
        }
    }
}
