using bangazon_inc.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.Entity;
using System.Net;
using bangazon_inc.Models;

namespace bangazon_inc.Controllers
{
    public class OrderDetailController : Controller
    {
        readonly IOrderDetailRepository _orderDetailRepository;
        
        public OrderDetailController(IOrderDetailRepository orderDetailRepository)
        {
            _orderDetailRepository = orderDetailRepository;
        }

        // GET: OrderDetail
        public ActionResult Order(int id)
        {
            ViewBag.OrderDetails = _orderDetailRepository.GetAllOrderDetail(id);
            return View("index");
        }
        
    }
}

