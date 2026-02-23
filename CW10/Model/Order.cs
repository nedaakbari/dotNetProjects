namespace CW10.Model
{
    public class Order
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid UserId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }

        public string PaymentMethod { get; set; }

        //DateTime.UtcNow;
        public DateTime CreatedAt { get; set; }

        public Order()
        {
        }

        public Order(Guid userId, Guid productId, int quantity)
        {
            if (userId == Guid.Empty) throw new ArgumentException("UserId cannot be empty.");
            if (productId == Guid.Empty) throw new ArgumentException("ProductId cannot be empty.");
            if (quantity <= 0) throw new ArgumentException("Quantity must be greater than 0.");

            UserId = userId;
            ProductId = productId;
            Quantity = quantity;

            /*
            UserId = userId ?? throw new Exception("User id cannot be empty");
            Products = products ?? throw new Exception("Products cannot be null");

            /*if (products == null) throw new Exception("Products cannot be null");
            Products = products;#1#
            // if (userId == null) throw new Exception("User id cannot be empty");*/
        }
    }
}