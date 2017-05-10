using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using bangazon_inc.DAL;
using bangazon_inc.Models;

namespace bangazon_inc.Controllers
{
    public class ProductController : Controller
    {
        private AppContext db = new AppContext();

        private readonly AppContext _context;


        // GET: Product
        public ActionResult Index()
        {
            return View(db.Products.ToList());
        }

        // GET: Product/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Price,Category,Description,Image")] Product product)
        {
            //var payment = new Payment { PaymentId = 1, PaymentName = "Visa", PaymentAccountNumber = 12340987, Customer = customer };
            //var customer = new Customer { CustomerId = 10, CustomerFirstName = "Taylor", CustomerLastName = "Harry", CustomerAddressLine1 = "123 Main Street", CustomerAddressLine2 = "Suite 1", CustomerCity = "Franklin", CustomerState = "TN", CustomerZipCode = "37069" };
            //var product11 = new Product { Id = 11, Name = "iPhone", Customer = customer, Price = 99.99m, Category = "Electronics", Description = "a phone", Image = "https://d3nevzfk7ii3be.cloudfront.net/igi/ipv5OG2NckM3DfE2.large" };
            var customer = new Customer { CustomerId = 1, CustomerFirstName = "Taylor", CustomerLastName = "Harry", CustomerAddressLine1 = "123 Main Street", CustomerAddressLine2 = "Suite 1", CustomerCity = "Franklin", CustomerState = "TN", CustomerZipCode = "37069" };

            product.Customer = customer;

            //_context.Products.Add(product);
            //_context.SaveChanges();
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }



            return View(product);
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Product/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Price,Category,Description,Image")] Product product)
        {
            if (!ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
