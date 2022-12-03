﻿using AutoMapper;
using Domain.Models;
using Domain.dtos;

namespace APIpayments.REST.Maps
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<AntiFraudCreditCard, AntiFraudCreditCardDTO>().ReverseMap();
        }
    }
}
