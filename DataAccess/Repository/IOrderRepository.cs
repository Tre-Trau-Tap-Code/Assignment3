using BusinessObject;

namespace DataAccess.Repository
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetOrders();
        Order GetOrderById(int id);
        void DeleteOrder(int id);
        void InsertOrder(Order order);
        void UpdateOrder();
    }
}