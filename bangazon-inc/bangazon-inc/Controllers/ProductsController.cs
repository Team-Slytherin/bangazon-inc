using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using bangazon_inc.DAL;
using bangazon_inc.Migrations;
using bangazon_inc.Models;

namespace bangazon_inc.Controllers
{
    public class ProductsController : Controller
    {
        private AppContext db = new AppContext();
        // GET: Products
        public ActionResult Index()
        {
            var categories = db.Categories.ToList();
            var customers = db.Customers.ToList();
            var viewModel = new CreateProductViewModel
            {
                Categories = categories.Select(x => new SelectListItem { Text = x.CategoryName, Value = x.CategoryId.ToString() }).ToList(),
                Customers = customers.Select(x => new SelectListItem { Text = x.CustomerFirstName + "" + x.CustomerLastName, Value = x.CustomerId.ToString() }).ToList(),
                ProductViewId = 2
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult CreateProduct(CreateProductViewModel product)
        {
            var res = new Product
            {
                
            };

            //res.DuckIAmEating = _duckRepository.Get(reservation.DuckId);

            //_reservationRepository.Save(res);

            return RedirectToAction("Index");
        }
    }
}