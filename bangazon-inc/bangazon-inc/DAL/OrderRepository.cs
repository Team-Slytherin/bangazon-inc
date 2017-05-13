using bangazon_inc.Interfaces;
using bangazon_inc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bangazon_inc.DAL
{
    public class OrderRepository : IOrderRepository
    {
        readonly AppContext _context;

        public OrderRepository(AppContext context)
        {
            _context = context;
        }
        public void EmptyOrder(Customer customer)
        {
            throw new NotImplementedException();
        }

        public void FinishOrder(Customer customer)
        {
            throw new NotImplementedException();
        }

        public Order GetActiveOrder(Customer customer)
        {
            return _context.Orders.Where(x => x.Customer.CustomerId == customer.CustomerId).FirstOrDefault();
        }

        public void InitOrder(Customer customer)
        {
            _context.Orders.Add(new Order { Customer = customer });
        }
    }
}