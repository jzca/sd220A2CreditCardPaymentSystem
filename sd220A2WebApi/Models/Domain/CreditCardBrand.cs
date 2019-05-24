using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sd220A2WebApi.Models.Domain
{
    public class CreditCardBrand
    {
        public int Id { get; set; }
        public string IdentificationNumber { get; set; }
        public string Brand { get; set; }
    }
}