using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bangazon_inc.Models;

namespace bangazon_inc.Interfaces
{
    public interface IProductRepository
    {
        void AddProduct(Product newProduct);
        IQueryable<Product> GetOneProduct(int productId);
        IEnumerable<Product> GetAllProducts();
        IEnumerable<string> GetAllProductCategories();
        void UpdateProduct(Product productToUpdate);
    }
}
