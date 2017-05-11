using bangazon_inc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bangazon_inc.Interfaces
{
    public interface IOrderRepository
    {
        void InitOrder(Customer customer);
        void GetActiveOrder(Customer customer);
        void FinishOrder(Customer customer);
        void EmptyOrder(Customer customer);
    }
}
