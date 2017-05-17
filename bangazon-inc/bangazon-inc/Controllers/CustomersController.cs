using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using bangazon_inc.DAL;
using bangazon_inc.Migrations;
using bangazon_inc.Models;
using bangazon_inc.Models.ProductsView;

namespace bangazon_inc.Controllers
{
    public class CustomersController : Controller
    {
        private readonly AppContext _db;

        public CustomersController(AppContext db)
        {
            _db = db;
        }

        // GET: show all Customers in a list
        public ActionResult Index()
        {
            return View(_db.Customers);
        }

        // show single customer (detail view)
        public ActionResult Details(int id)
        {
            return View(_db.Customers.Find(id));
        }

        // show single customer (edit view)
        public ActionResult Edit(int id)
        {
            return View(_db.Customers.Find(id));
        }
        // show single customer (add view)
        public ActionResult Create()
        {
            return View();
        }

        // ADD new customer to the DB
        [HttpPost]
        public ActionResult Create(CreateCustomerViewModel customer)
        {
            var newCustomer = new Customer
            {
                CustomerFirstName = customer.FirstName,
                CustomerLastName = customer.LastName,
                CustomerAddressLine1 = customer.AddressLine1,
                CustomerAddressLine2 = customer.AddressLine2,
                CustomerCity = customer.City,
                CustomerState = customer.State,
                CustomerZipCode = customer.ZipCode
            };

            _db.Customers.Add(newCustomer);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        // Edit existing customer to the DB
        [HttpPost]
        public ActionResult Edit(CreateCustomerViewModel customer)
        {
            var editedCustomer = new Customer
            {
                CustomerFirstName = customer.FirstName,
                CustomerLastName = customer.LastName,
                CustomerAddressLine1 = customer.AddressLine1,
                CustomerAddressLine2 = customer.AddressLine2,
                CustomerCity = customer.City,
                CustomerState = customer.State,
                CustomerZipCode = customer.ZipCode
            };

            _db.Customers.AddOrUpdate(editedCustomer);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        
        // DELETE existing customer from the DB 
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var customerToDelete = _db.Customers.Find(id);
            _db.Customers.Remove(customerToDelete);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}