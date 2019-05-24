﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sd220A2WebApi.Models.Domain
{

    public class Payment
    {
        public int Id { get; set; }
        public virtual CreditCardBrand CreditCardBrand { get; set; }
        public int CreditCardBrandId { get; set; }
        public decimal Amount { get; set; }
        public string NameOnCard { get; set; }
        public int CreditCardNumber { get; set; }
        public string SecurityCode { get; set; }
        public  bool IsRejected { get; set; }
    }
}