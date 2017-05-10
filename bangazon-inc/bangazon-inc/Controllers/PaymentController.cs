using bangazon_inc.Interfaces;
using bangazon_inc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace bangazon_inc.Controllers
{
    [RoutePrefix("payment")]
    public class PaymentController : Controller
    {
        private readonly IPaymentRepository _paymentRepository;
        public PaymentController(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        [HttpGet]
        [Route("{paymentId}")]
        public ActionResult RetrievePayment(int paymentId)
        {
            var payment = _paymentRepository.GetSinglePayment(paymentId);

            if (payment == null)
            {
                return HttpNotFound("No Content: Payment Option Does Not Exist.");
            }

            return View("PaymentInfo", payment);
        }

        [HttpGet]
        public ActionResult RetrieveAllPayments()
        {
            var paymentList = _paymentRepository.GetAllPayments() as List<Payment>;

            if (paymentList == null)
            {
                return HttpNotFound("No Content: No Payment Options Available.");
            }

            return View("PaymentList", paymentList);
        }
        [HttpGet]
        [Route("{paymentId}")]
        public ActionResult RetrieveEditPaymentForm(int paymentId)
        {
            var payment = _paymentRepository.GetSinglePayment(paymentId);

            if (payment == null)
            {
                return HttpNotFound("No Content: Payment Does Not Exist.");
            }

            return View("PaymentInfoForm", payment);
        }

        [HttpPut]
        //[Route("{customerId}")]
        public ActionResult EditPayment(Payment payment)
        {
            if (!ModelState.IsValid)
            {
                return HttpNotFound("No Content: Select a Valid Payment to Edit.");
            }
            var updatedCustomer = _paymentRepository.EditPayment(payment);

            return View("CustomerDetail", payment);
        }

    }
}
