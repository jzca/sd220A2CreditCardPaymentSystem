﻿using AutoMapper;
using sd220A2WebApi.Models;
using sd220A2WebApi.Models.Domain;
using sd220A2WebApi.Models.BindViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HouseholdBudgeterAPI.App_Start
{
    public static class AutoMapperConfig
    {
        public static void Init()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<CreditCardBrand, CreditCardBrandViewModel>().ReverseMap();
                cfg.CreateMap<Payment, PaymentBindingModel>().ReverseMap();
                cfg.CreateMap<Payment, PaymentViewModel>().ReverseMap();
            });
        }
    }
}