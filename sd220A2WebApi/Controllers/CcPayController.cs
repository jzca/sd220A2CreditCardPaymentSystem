using AutoMapper;
using AutoMapper.QueryableExtensions;
using sd220A2WebApi.Models;
using sd220A2WebApi.Models.BindViewModel;
using sd220A2WebApi.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace sd220A2WebApi.Controllers
{
    public class CcPayController : ApiController
    {
        private readonly ApplicationDbContext DbContext;

        public CcPayController()
        {
            DbContext = new ApplicationDbContext();
        }

        [HttpGet]
        public IHttpActionResult GetAllCcb()
        {
            var ccbsModel = DbContext
                .CreditCardBrands
                .ProjectTo<CreditCardBrandViewModel>()
                .ToList();

            return Ok(ccbsModel);
        }

        [HttpPost]
        public IHttpActionResult CreatePayment(PaymentBindingModel formData)
        {
            if (formData == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var Ccb = DbContext
                .CreditCardBrands
                .FirstOrDefault(p => p.Id == formData.CreditCardBrandId);

            if (Ccb == null)
            {
                ModelState.AddModelError("CreditCardBrandId",
                    "This is not valid. No record in the system.");
                return BadRequest(ModelState);
            }

            if (formData.Amount <= 0)
            {
                ModelState.AddModelError("Amount",
                    "It must be greater than 0.");
                return BadRequest(ModelState);
            }

            if (!formData.SecurityCode.All(char.IsDigit))
            {
                ModelState.AddModelError("SecurityCode",
                    "It must be a number");
                return BadRequest(ModelState);
            }


            var payment = Mapper.Map<Payment>(formData);

            RejectPaymentLottery(payment);

            DbContext.Payments.Add(payment);
            DbContext.SaveChanges();

            if (payment.IsRejected)
            {
                ModelState.AddModelError("Status",
                    "Sorry. Payment is rejected.");
                return BadRequest(ModelState);
            }

            var viewModel = Mapper.Map<PaymentViewModel>(payment);

            return Ok(viewModel);
        }

        private void RejectPaymentLottery(Payment payment)
        {
            Random rdm = new Random();
            var resultStatus = rdm.Next(101);

            if (resultStatus <= 50)
            {
                payment.IsRejected = true;
            }
        }

    }
}
