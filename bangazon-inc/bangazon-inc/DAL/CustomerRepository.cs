using bangazon_inc.Interfaces;
using bangazon_inc.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace bangazon_inc.DAL
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IDbConnection _dbConnection;
        public CustomerRepository(IDbConnection connection)
        {
            _dbConnection = connection;
        }
       
        public int EditCustomer(Customer editingCustomer)
        {
            var sql = $@"UPDATE SlytherBang.dbo.Customer
                         SET CustomerName = @CustomerName,
                             CustomerStreetAddress = @CustomerStreetAddress,
                             CustomerCity = @CustomerCity,
                             CustomerState = @CustomerState,
                             CustomerZip = @CustomerZip,
                             CustomerPhone = @CustomerPhone
                        WHERE CustomerId = @CustomerId;";
            var count = _dbConnection.Execute(sql, editingCustomer);

            return count;
        }

        public Customer GetSingleCustomer(int customerId)
        {
            var sql = $@"SELECT *
                        FROM SlytherBang.dbo.Customer
                        WHERE CustomerId = {customerId};";

            var result = _dbConnection.Query<Customer>(sql).ToList();

            return result.FirstOrDefault();
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            var sql = $@"SELECT * FROM SlytherBang.dbo.Customer;";

            return _dbConnection.Query<Customer>(sql).ToList();

        }
    }
}