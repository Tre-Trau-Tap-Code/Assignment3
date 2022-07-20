using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    internal class OrderDAO : eStoreContext
    {
        private static OrderDAO instance = null;
        private static readonly object instanceLock = new object();
        public static OrderDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new OrderDAO();
                    }
                    return instance;
                }
            }
        }
        public IEnumerable<Order> GetOrders() => Orders.ToList();
        public Order GetOrderById(int id) => Orders.Find(id);
        public void InsertOrder(Order order) { Orders.Add(order); SaveChanges(); }
        public void DeleteOrder(int id) { Orders.Remove(GetOrderById(id)); SaveChanges(); }
        public void UpdateOrder() => SaveChanges();
    }
}
