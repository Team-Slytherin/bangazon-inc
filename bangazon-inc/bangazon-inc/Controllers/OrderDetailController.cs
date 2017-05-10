using bangazon_inc.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace bangazon_inc.Controllers
{
    public class OrderDetailController : Controller
    {
        readonly IOrderDetailRepository _orderDetailRepository;
        public OrderDetailController()
        {
            _orderDetailRepository = new OrderDetailRepository();
        }
        public OrderDetailController(IOrderDetailRepository orderDetailRepository)
        {
            _orderDetailRepository = orderDetailRepository;
        }
        // GET: OrderDetail
        public ActionResult Index()
        {
            return View("index");
        }

        // GET: OrderDetail
        [HttpGet]
        [Route]
        public ActionResult Order(int id)
        {
            //_orderDetailRepository.Save(newDuck);
            return View("index");
        }
    }
}