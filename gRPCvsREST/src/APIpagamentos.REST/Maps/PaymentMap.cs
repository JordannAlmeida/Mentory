using AutoMapper;
using Domain.dtos;
using Domain.httpModels.rest;

namespace APIpayments.REST.Maps
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<CreditCardDTO, CreditCardAntifraudRequest>().ReverseMap();
        }
    }
}
