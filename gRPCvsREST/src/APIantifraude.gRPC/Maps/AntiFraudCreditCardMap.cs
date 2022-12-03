using AutoMapper;
using Domain.Models;
using Domain.httpModels.proto;
using Domain.httpModels.rest;

namespace APIpayments.REST.Maps
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<AntiFraudCreditCard, AntiFraudResponseGRPC>().ReverseMap();
            CreateMap<CreditCardGRPC, CreditCardAntifraudRequest>().ReverseMap();
        }
    }
}
