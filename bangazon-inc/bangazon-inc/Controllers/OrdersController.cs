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
using bangazon_inc.Interfaces;

namespace bangazon_inc.Controllers
{
    public class OrdersController : Controller
    {
        private AppContext db = new AppContext();
        readonly IOrderRepository _orderRepository;

        public OrdersController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        // GET: Orders
        public ActionResult Index()
        {
            return View(db.Orders.ToList());
        }

        // GET: ActiveOrder
        public ActionResult ActiveOrder()
        {
            MyGlobalVariables.activeCustomer = db.Customers.Find(3);
            var cartId = db.Orders.Where(x => x.Customer.CustomerId == MyGlobalVariables.activeCustomer.CustomerId && x.OrderActive == "1").First().OrderId;
            return RedirectToAction("Order", "OrderDetail", new { id = cartId});
        }

        // GET: Orders/s/5
        public ActionResult s(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return RedirectToAction("Order", "OrderDetail", new { id = id});
        }

        // GET: Orders/Create
        public ActionResult Create()
        {
            Order order = new Order();
            order.Customer = db.Customers.Find(2);
            order.Payment = db.Payments.Find(2);
            order.Payment.Customer = order.Customer;
            return View(order);
        }

        // POST: Orders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrderId,OrderActive,Customer,Payment")] Order order)
        {
            if (ModelState.IsValid)
            {
                var newOrder = new Order
                {
                    Customer = db.Customers.Find(order.Customer.CustomerId),
                    Payment = db.Payments.Find(order.Payment.PaymentId),
                    OrderActive = order.OrderActive
                };
                db.Orders.Add(newOrder);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View("Orders");
        }

        // GET: Orders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrderId,OrderActive")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(order);
        }

        // GET: Orders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Order order = db.Orders.Find(id);
            db.Orders.Remove(order);
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
