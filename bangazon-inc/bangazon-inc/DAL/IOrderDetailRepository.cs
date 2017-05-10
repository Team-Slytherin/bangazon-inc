using bangazon_inc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bangazon_inc.DAL
{
    public interface IOrderDetailRepository
    {
        void GetOrderDetail(int orderId);
        void Save(OrderDetail orderDetail);
    }
}
