using bangazon_inc.Models;

namespace bangazon_inc.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<bangazon_inc.DAL.AppContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DAL.AppContext context)
        {
            var customer = new Customer { CustomerId = 1, CustomerFirstName = "Taylor", CustomerLastName = "Harry", CustomerAddressLine1 = "123 Main Street", CustomerAddressLine2 = "Suite 1", CustomerCity = "Franklin", CustomerState = "TN", CustomerZipCode = "37069" };
            var customer2 = new Customer { CustomerId = 2, CustomerFirstName = "Justin", CustomerLastName = "Leggett", CustomerAddressLine1 = "123 Main Street", CustomerAddressLine2 = "Suite 1", CustomerCity = "Franklin", CustomerState = "TN", CustomerZipCode = "37069" };
            var customer3 = new Customer { CustomerId = 3, CustomerFirstName = "Bin", CustomerLastName = "Li", CustomerAddressLine1 = "123 Main Street", CustomerAddressLine2 = "Suite 1", CustomerCity = "Franklin", CustomerState = "TN", CustomerZipCode = "37069" };
            var customer4 = new Customer { CustomerId = 4, CustomerFirstName = "Dustin", CustomerLastName = "Reed", CustomerAddressLine1 = "123 Main Street", CustomerAddressLine2 = "Suite 1", CustomerCity = "Franklin", CustomerState = "TN", CustomerZipCode = "37069" };
            var customer5 = new Customer { CustomerId = 5, CustomerFirstName = "Debgra", CustomerLastName = "Gordon", CustomerAddressLine1 = "123 Main Street", CustomerAddressLine2 = "Suite 1", CustomerCity = "Franklin", CustomerState = "TN", CustomerZipCode = "37069" };

            var product = new Product { Id = 1, Name = "iPhone", Customer = customer, Price = 99.99m, Category = "Electronics", Description = "a phone", Image = "https://d3nevzfk7ii3be.cloudfront.net/igi/ipv5OG2NckM3DfE2.large" };
            var product2 = new Product { Id = 2, Name = "iPhone", Customer = customer, Price = 99.99m, Category = "Electronics", Description = "a phone", Image = "https://d3nevzfk7ii3be.cloudfront.net/igi/ipv5OG2NckM3DfE2.large" };
            var product3 = new Product { Id = 3, Name = "iPhone", Customer = customer, Price = 99.99m, Category = "Electronics", Description = "a phone", Image = "https://d3nevzfk7ii3be.cloudfront.net/igi/ipv5OG2NckM3DfE2.large" };
            var product4 = new Product { Id = 4, Name = "iPhone", Customer = customer, Price = 99.99m, Category = "Electronics", Description = "a phone", Image = "https://d3nevzfk7ii3be.cloudfront.net/igi/ipv5OG2NckM3DfE2.large" };
            var product5 = new Product { Id = 5, Name = "iPhone", Customer = customer, Price = 99.99m, Category = "Electronics", Description = "a phone", Image = "https://d3nevzfk7ii3be.cloudfront.net/igi/ipv5OG2NckM3DfE2.large" };
            var product6 = new Product { Id = 6, Name = "iPhone", Customer = customer, Price = 99.99m, Category = "Electronics", Description = "a phone", Image = "https://d3nevzfk7ii3be.cloudfront.net/igi/ipv5OG2NckM3DfE2.large" };
            var product7 = new Product { Id = 7, Name = "iPhone", Customer = customer, Price = 99.99m, Category = "Electronics", Description = "a phone", Image = "https://d3nevzfk7ii3be.cloudfront.net/igi/ipv5OG2NckM3DfE2.large" };
            var product8 = new Product { Id = 8, Name = "iPhone", Customer = customer, Price = 99.99m, Category = "Electronics", Description = "a phone", Image = "https://d3nevzfk7ii3be.cloudfront.net/igi/ipv5OG2NckM3DfE2.large" };
            var product9 = new Product { Id = 9, Name = "iPhone", Customer = customer, Price = 99.99m, Category = "Electronics", Description = "a phone", Image = "https://d3nevzfk7ii3be.cloudfront.net/igi/ipv5OG2NckM3DfE2.large" };
            var product10 = new Product { Id = 10, Name = "iPhone", Customer = customer, Price = 99.99m, Category = "Electronics", Description = "a phone", Image = "https://d3nevzfk7ii3be.cloudfront.net/igi/ipv5OG2NckM3DfE2.large" };

            var payment = new Payment { PaymentId = 1, PaymentName = "Visa", PaymentAccountNumber = 12340987, Customer = customer };
            var payment2 = new Payment { PaymentId = 2, PaymentName = "Visa", PaymentAccountNumber = 12340987, Customer = customer2 };
            var payment3 = new Payment { PaymentId = 3, PaymentName = "Visa", PaymentAccountNumber = 12340987, Customer = customer3 };
            var payment4 = new Payment { PaymentId = 4, PaymentName = "Visa", PaymentAccountNumber = 12340987, Customer = customer4 };
            var payment5 = new Payment { PaymentId = 5, PaymentName = "Visa", PaymentAccountNumber = 12340987, Customer = customer5 };

            var order = new Order { OrderId = 1, OrderActive = "1", Customer = customer, Payment = payment };
            var order2 = new Order { OrderId = 2, OrderActive = "1", Customer = customer2, Payment = payment2 };
            var order3 = new Order { OrderId = 3, OrderActive = "1", Customer = customer3, Payment = payment3 };
            var order4 = new Order { OrderId = 4, OrderActive = "1", Customer = customer4, Payment = payment4 };
            var order5 = new Order { OrderId = 5, OrderActive = "1", Customer = customer5, Payment = payment5 };

            var orderdetail = new OrderDetail { OrderDetailId = 1, Order = order, Product = product };
            var orderdetail2 = new OrderDetail { OrderDetailId = 2, Order = order, Product = product2 };
            var orderdetail3 = new OrderDetail { OrderDetailId = 3, Order = order2, Product = product2 };
            var orderdetail4 = new OrderDetail { OrderDetailId = 4, Order = order2, Product = product3 };
            var orderdetail5 = new OrderDetail { OrderDetailId = 5, Order = order3, Product = product6 };
            var orderdetail6 = new OrderDetail { OrderDetailId = 6, Order = order3, Product = product5 };
            var orderdetail7 = new OrderDetail { OrderDetailId = 7, Order = order4, Product = product5 };
            var orderdetail8 = new OrderDetail { OrderDetailId = 8, Order = order4, Product = product4 };
            var orderdetail9 = new OrderDetail { OrderDetailId = 9, Order = order5, Product = product7 };
            var orderdetail10 = new OrderDetail { OrderDetailId = 10, Order = order5, Product = product8 };

            context.Customers.AddOrUpdate(
                customer, customer2, customer3, customer4, customer5
            );

            context.Products.AddOrUpdate(
                product, product2, product3, product4, product5, product6, product7, product8, product9, product10
            );

            context.Payments.AddOrUpdate(
                payment, payment2, payment3, payment4, payment5
            );

            context.Orders.AddOrUpdate(
                order, order2, order3, order4, order5
            );

            context.OrderDetails.AddOrUpdate(
                orderdetail, orderdetail2, orderdetail3, orderdetail4, orderdetail5, orderdetail6, orderdetail7, orderdetail8, orderdetail9, orderdetail10
            );

        }
    }
}
