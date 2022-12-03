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
            CreateMap<AntiFraudCreditCard, AntiFraudResponseGRPC>()
                .ForMember(antiFraud => antiFraud.Aproved, map => map.MapFrom(antiFraudRPC => antiFraudRPC.Aproved))
                .ForMember(antiFraud => antiFraud.Message, map => map.MapFrom(antiFraudRPC => antiFraudRPC.Message))
                .ForMember(antiFraud => antiFraud.PercentageOfRiskGatewayA, map => map.MapFrom(antiFraudRPC => antiFraudRPC.PercentageOfRiskGatewayA))
                .ForMember(antiFraud => antiFraud.PercentageOfRiskGatewayB, map => map.MapFrom(antiFraudRPC => antiFraudRPC.PercentageOfRiskGatewayB))
                .ForMember(antiFraud => antiFraud.PercentageOfRiskGatewayC, map => map.MapFrom(antiFraudRPC => antiFraudRPC.PercentageOfRiskGatewayC))
                .ForMember(antiFraud => antiFraud.PercentageOfRiskGatewayD, map => map.MapFrom(antiFraudRPC => antiFraudRPC.PercentageOfRiskGatewayD))
                .ForMember(antiFraud => antiFraud.PercentageOfRiskGatewayE, map => map.MapFrom(antiFraudRPC => antiFraudRPC.PercentageOfRiskGatewayE));
        }
    }
}
