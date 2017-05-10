using System.Collections.Generic;
using System.Data;
using System.Linq;
using bangazon_inc.Interfaces;
using bangazon_inc.Models;
using Dapper;

namespace bangazon_inc.DAL
{
    public class ProductRepository : IProductRepository
    {
        private readonly IDbConnection _dbConnection;

        public ProductRepository(IDbConnection connection)
        {
            _dbConnection = connection;
        }
        public void AddProduct(Product newProduct)
        {
            const string sql = @"INSERT into BangazonInc.dbo.Product
                        (ProductName,
                         ProductPrice)
                        VALUES
                        (@ProductName,
                         @ProductPrice);";
            _dbConnection.Execute(sql, newProduct);
        }

        public IEnumerable<Product> GetAllProducts()
        {
            var sql = $@"SELECT * FROM BangazonInc.dbo.Product;";
            return _dbConnection.Query<Product>(sql).ToList();
        }

        public Product GetOneProduct(int productId)
        {
            var sql = $@"SELECT *
                        FROM BangazonInc.dbo.Product
                        WHERE ProductId = {productId};";
            var result = _dbConnection.Query<Product>(sql).ToList();
            return result.FirstOrDefault();
        }

        public void UpdateProduct(Product productToUpdate)
        {
            const string sql = @"UPDATE Product
                        SET ProductName to @ProductName
                            ProductPrice to @ProductPrice
                        WHERE ProductId = @ProductId";
            _dbConnection.Execute(sql, new { productToUpdate });
        }
    }
}