using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    internal class OrderDetailDAO : eStoreContext
    {
        private static OrderDetailDAO instance = null;
        private static readonly object instanceLock = new object();
        public static OrderDetailDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new OrderDetailDAO();
                    }
                    return instance;
                }
            }
        }
        public IEnumerable<OrderDetail> GetOrderDetails() => OrderDetails.ToList();
        public OrderDetail GetOrderDetailByOrderIdAndProductId(int orderId, int productId) => OrderDetails.Find(orderId, productId);
        public void InsertOrderDetail(OrderDetail orderDetail) { OrderDetails.Add(orderDetail); SaveChanges(); }
        public void UpdateOrderDetail() => SaveChanges();
        public void DeleteOrderDetail(int orderId, int productId) { OrderDetails.Remove(GetOrderDetailByOrderIdAndProductId(orderId, productId));SaveChanges(); }
    }
}
