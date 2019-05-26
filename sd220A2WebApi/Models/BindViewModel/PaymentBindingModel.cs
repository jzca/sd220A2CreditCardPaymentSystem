using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace sd220A2WebApi.Models.Domain
{

    public class PaymentBindingModel
    {
        [Required]
        public int CreditCardBrandId { get; set; }
        [Required]
        public decimal Amount { get; set; }
        [Required]
        public string NameOnCard { get; set; }
        [Required]
        [CreditCard]
        public string CreditCardNumber { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(4)]
        public string SecurityCode { get; set; }
    }
}