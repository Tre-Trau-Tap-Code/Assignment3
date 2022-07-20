using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class ProductRepository : IProductRepository
    {
        public void DeleteProduct(int id) => ProductDAO.Instance.DeleteProduct(id);
        public Product GetProductById(int id) => ProductDAO.Instance.GetProductById(id);
        public IEnumerable<Product> GetProductByName(string name) => ProductDAO.Instance.GetProductByName(name);
        public IEnumerable<Product> GetProducts() => ProductDAO.Instance.GetProducts();
        public void InsertProduct(Product product) => ProductDAO.Instance.InsertProduct(product);
        public void UpdateProduct() => ProductDAO.Instance.UpdateProduct();
    }
}
