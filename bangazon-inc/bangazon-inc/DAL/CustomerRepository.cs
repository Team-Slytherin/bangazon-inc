using bangazon_inc.Interfaces;
using bangazon_inc.Models;
using System.Collections.Generic;
using System.Data.Entity;

namespace bangazon_inc.DAL
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AppContext _appContext;

        public CustomerRepository(AppContext appContext)
        {
            _appContext = appContext;
        }
       
        public int EditCustomer(Customer editingCustomer)
        {
            var modifiedCustomer = _appContext.Entry(editingCustomer);
            modifiedCustomer.State = EntityState.Modified;

            return _appContext.SaveChanges();
        }

        public Customer GetSingleCustomer(int customerId)
        {
            return _appContext.Customers.Find(customerId);
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return _appContext.Customers;
        }
    }
}