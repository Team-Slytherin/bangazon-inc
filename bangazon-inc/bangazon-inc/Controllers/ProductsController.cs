using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using bangazon_inc.DAL;
using bangazon_inc.Migrations;
using bangazon_inc.Models;
using bangazon_inc.Models.ProductsView;
using System.Net;
using System.Data.Entity;

namespace bangazon_inc.Controllers
{
    public class ProductsController : Controller
    {
        private AppContext db = new AppContext();

        // GET: Products
        public ActionResult All()
        {
            return View(db.Products.ToList());
        }

        public ActionResult Index()
        {
            var categories = db.Categories.ToList();
            var customers = db.Customers.ToList();
            var viewModel = new CreateProductViewModel
            {
                Categories = categories.Select(x => new SelectListItem { Text = x.CategoryName, Value = x.CategoryId.ToString() }).ToList(),
                Customers = customers.Select(x => new SelectListItem { Text = x.CustomerFirstName + "" + x.CustomerLastName, Value = x.CustomerId.ToString() }).ToList()
            };

            return View(viewModel);
        }

        public ActionResult category(int id)
        {
            var products = db.Products.Where(x => x.Category.CategoryId == id).ToList();
            return View(products);
        }

        [HttpPost]
        public ActionResult CreateProduct(CreateProductViewModel product)
        {
            var res = new Product
            {
                Category = db.Categories.Find(product.CategoryId),
                Description = product.Description,
                Customer = db.Customers.Find(product.CustomerId),
                Image = product.Image,
                Name = product.Name,
                Price = product.Price
            };

            db.Products.Add(res);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult SaveToCart(int ProductId, int CategoryId)
        {
            MyGlobalVariables.activeCustomer = db.Customers.Find(3);
            var order = db.Orders.Find(MyGlobalVariables.activeCustomer.CustomerId);
            var newOrderDetail = new OrderDetail
            {
                Order = db.Orders.Find(order.OrderId),
                Product = db.Products.Find(ProductId)
            };

            db.OrderDetails.Add(newOrderDetail);
            db.SaveChanges();
            return RedirectToAction("category", "Products", new { id = CategoryId });
        }

        // GET: Products/Edit/5
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
            Session["_productId"] = id;
            var categories = db.Categories.ToList();
            var customers = db.Customers.ToList();
            var viewModel = new CreateProductViewModel
            {
                Categories = categories.Select(x => new SelectListItem { Text = x.CategoryName, Value = x.CategoryId.ToString() }).ToList(),
                Customers = customers.Select(x => new SelectListItem { Text = x.CustomerFirstName + "" + x.CustomerLastName, Value = x.CustomerId.ToString() }).ToList(),
                CategoryId = product.Category.CategoryId,
                Description = product.Description,
                CustomerId = product.Customer.CustomerId,
                Image = product.Image,
                Name = product.Name,
                Price = product.Price
            };

            return View(viewModel);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Edit(CreateProductViewModel product)
        {
            var _productId = Session["_productId"];
            Product res = db.Products.Where(x => x.ProductId == (int)_productId).Single();
            res.Category = db.Categories.Find(product.CategoryId);
            res.Description = product.Description;
            res.Customer = db.Customers.Find(product.CustomerId);
            res.Image = product.Image;
            res.Name = product.Name;
            res.Price = product.Price;
            db.Entry(res).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("category", "Products", new { id = product.CategoryId });
        }

        // GET: Products/Delete/5
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

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            var categoryId = product.Category.CategoryId;
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("category", "Products", new { id = categoryId });
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