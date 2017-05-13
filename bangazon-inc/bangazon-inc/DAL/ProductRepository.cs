using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Migrations;
using System.Linq;
using bangazon_inc.Interfaces;
using bangazon_inc.Models;
using Dapper;

namespace bangazon_inc.DAL
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppContext _context;

        public ProductRepository(AppContext context)
        {
            _context = context;
        }
        public void AddProduct(Product newProduct)
        {
            _context.Products.Add(newProduct);
            _context.SaveChanges();
        }

        public IEnumerable<Category> GetAllProductCategories()
        {
            return _context.Categories.ToList();
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _context.Products;
        }

        public IQueryable<Product> GetOneProduct(int productId)
        {
            return _context.Products.Where(x => x.ProductId == productId);
        }

        public void UpdateProduct(Product productToUpdate)
        {
            _context.Products.AddOrUpdate(productToUpdate);
        }
    }
}