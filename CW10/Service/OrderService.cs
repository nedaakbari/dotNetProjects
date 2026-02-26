using System.Text;
using CW10.Model;
using CW10.Repository.Interfaces;
using CW10.Service.payments;

namespace CW10.Service
{
    internal class OrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;

        public OrderService(IOrderRepository orderRepository, IProductRepository productRepository)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
        }

        public Order CreateOrder(Guid userId, Product product /*List<Product> products*/, int quantity)
        {
            /*var product = _productRepository.GetById(productId) ??
                          throw new InvalidOperationException("Product not found.");*/
            if (product.Stock < quantity) throw new InvalidOperationException("Not enough stock.");

            var order = new Order(userId, product, quantity);
            product.DecreaseStock(quantity);

            _productRepository.Update(product);
            _orderRepository.Add(order);

            return order;
        }

        private void ValidateOrder(Guid userId, Guid productId, int quantity)
        {
            if (userId == Guid.Empty) throw new ArgumentException("UserId cannot be empty.");
            if (productId == Guid.Empty) throw new ArgumentException("ProductId cannot be empty.");
            if (quantity <= 0) throw new ArgumentException("Quantity must be greater than 0.");
        }

        public List<Order> GetAllOrdersOfUser(Guid userId)
        {
            return _orderRepository.GetByUserId(userId);
        }

        public void PayOrder(Guid userId, Guid orderId, Payment payment)
        {
            var order = GetOrder(orderId);
            if (order.UserId != userId) throw new UnauthorizedAccessException("this order not belongs to you");

            payment.Pay();
            order.PaymentMethod = payment.MethodName();
            // order.CreatedAt == DateTime.Now;
            _orderRepository.Update(order);
        }

        private Order GetOrder(Guid orderId)
        {
            return _orderRepository.GetById(orderId) ?? throw new KeyNotFoundException("order not found.");
        }
    }
}