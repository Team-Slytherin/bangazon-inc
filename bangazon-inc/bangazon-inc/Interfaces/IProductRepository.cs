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
        Product GetOneProduct(int productId);
        IEnumerable<Product> GetAllProducts();
        void UpdateProduct(Product productToUpdate);
    }
}
