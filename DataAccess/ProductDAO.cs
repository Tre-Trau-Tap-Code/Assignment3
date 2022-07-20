using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    internal class ProductDAO : eStoreContext
    {
        private static ProductDAO instance = null;
        private static readonly object instanceLock = new object();
        public static ProductDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new ProductDAO();
                    }
                    return instance;
                }
            }
        }
        public IEnumerable<Product> GetProducts() => Products.ToList();
        public Product GetProductById(int id) => Products.Find(id);
        public IEnumerable<Product> GetProductByName(string name) => Products.Where(product => product.ProductName.ToLower().Contains(name.ToLower())).ToList();
        public void DeleteProduct(int id) { Products.Remove(GetProductById(id)); SaveChanges(); }
        public void InsertProduct(Product product) { Products.Add(product); SaveChanges(); }
        public void UpdateProduct() => SaveChanges();
    }
}
