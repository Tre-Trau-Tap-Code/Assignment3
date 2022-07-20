using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class OrderRepository : IOrderRepository
    {
        public void DeleteOrder(int id) => OrderDAO.Instance.DeleteOrder(id);
        public Order GetOrderById(int id) => OrderDAO.Instance.GetOrderById(id);
        public IEnumerable<Order> GetOrders() => OrderDAO.Instance.GetOrders();
        public void InsertOrder(Order order) => OrderDAO.Instance.InsertOrder(order);
        public void UpdateOrder() => OrderDAO.Instance.UpdateOrder();
    }
}
