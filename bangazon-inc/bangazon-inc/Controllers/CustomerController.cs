using bangazon_inc.Interfaces;
using bangazon_inc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace bangazon_inc.Controllers
{
    [RoutePrefix("customer")]
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [HttpGet]
        [Route("{customerId}")]
        public ActionResult RetrieveCustomer(int customerId)
        {
            var customer = _customerRepository.GetSingleCustomer(customerId);

            if (customer == null)
            {
                return HttpNotFound("No Content: Customer Does Not Exist.");
            }

            return View("CustomerDetail", customer);
        }

        [HttpGet]
        public ActionResult RetrieveAllCustomers()
        {
            var customers = _customerRepository.GetAllCustomers() as List<Customer>;

            if (customers == null)
            {
                return HttpNotFound("No Content: No Customers Available.");
            }

            return View("CustomerList", customers);
        }
        [HttpGet]
        [Route("{customerId}")]
        public ActionResult RetrieveEditCustomerForm(int customerId)
        {
            var customer = _customerRepository.GetSingleCustomer(customerId);

            if (customer == null)
            {
                return HttpNotFound("No Content: Customer Does Not Exist.");
            }

            return View("CustomerEdit", customer);
        }

        [HttpPut]
        //[Route("{customerId}")]
        public ActionResult EditCustomer (Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return HttpNotFound("No Content: Select a Valid Customer to Edit.");
            }
            var updatedCustomer = _customerRepository.EditCustomer(customer);

            return View("CustomerDetail", customer);
        }
    }
}