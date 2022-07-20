using BusinessObject;

namespace DataAccess.Repository
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        public void DeleteOrderDetail(int orderId, int productId) => OrderDetailDAO.Instance.DeleteOrderDetail(orderId, productId);
        public OrderDetail GetOrderDetailByOrderIdAndProductId(int orderId, int productId) => OrderDetailDAO.Instance.GetOrderDetailByOrderIdAndProductId(orderId,productId);
        public IEnumerable<OrderDetail> GetOrderDetails() => OrderDetailDAO.Instance.GetOrderDetails();
        public void InsertOrderDetail(OrderDetail orderDetail) => OrderDetailDAO.Instance.InsertOrderDetail(orderDetail);
        public void UpdateOrderDetail(OrderDetail orderDetail) => OrderDetailDAO.Instance.UpdateOrderDetail();
    }
}