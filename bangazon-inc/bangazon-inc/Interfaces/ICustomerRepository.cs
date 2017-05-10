using bangazon_inc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bangazon_inc.Interfaces
{
    public interface ICustomerRepository
    {
        int EditCustomer(Customer editingCustomer);
        Customer GetSingleCustomer(int customerId);
        IEnumerable<Customer> GetAllCustomers();
    }
}
