using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using bangazon_inc.Models;

namespace bangazon_inc.DAL
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        readonly AppContext _context;

        public OrderDetailRepository(AppContext context)
        {
            _context = context;
        }
        public List<OrderDetail> GetAllOrderDetail(int orderId)
        {
            return _context.OrderDetails.Where(x => x.Order.OrderId == orderId).ToList();
        }

        public void Save(OrderDetail orderDetail)
        {
            throw new NotImplementedException();
        }
    }
}