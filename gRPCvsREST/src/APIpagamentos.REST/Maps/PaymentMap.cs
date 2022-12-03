using AutoMapper;
using Domain.dtos;
using Domain.httpModels.rest;
using Domain.httpModels.proto;
using Google.Protobuf.WellKnownTypes;

namespace APIpayments.REST.Maps
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<CreditCardDTO, CreditCardAntifraudRequest>().ReverseMap();
            CreateMap<CreditCardDTO, CreditCardGRPC>()
                .ForMember(card => card.Cvv, map => map.MapFrom(cardDTO=> cardDTO.Cvv))
                .ForMember(card => card.Latitude, map => map.MapFrom(cardDTO => cardDTO.Latitude))
                .ForMember(card => card.Longitude, map => map.MapFrom(cardDTO => cardDTO.Longitude))
                .ForMember(card => card.CodeBank, map => map.MapFrom(cardDTO => cardDTO.CodeBank))
                .ForMember(card => card.CreditCardAmoun, map => map.MapFrom(cardDTO => cardDTO.CreditCardAmoun))
                .ForMember(card => card.CreditCardLimit, map => map.MapFrom(cardDTO => cardDTO.CreditCardLimit))
                .ForMember(card => card.CreditCardNumber, map => map.MapFrom(cardDTO => cardDTO.CreditCardNumber))
                .ForMember(card => card.NameOwner, map => map.MapFrom(cardDTO => cardDTO.NameOwner))
                .ForMember(card => card.PaymentDate, map => map.MapFrom(cardDTO => Timestamp.FromDateTimeOffset(cardDTO.PaymentDate)))
                .ForMember(card => card.Validate, map => map.MapFrom(cardDTO => Timestamp.FromDateTimeOffset(cardDTO.Validate)));

        }
    }
}
