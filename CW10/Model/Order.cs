using System.Text;

namespace CW10.Model
{
    public class Order
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid UserId { get; set; }

        // public List<Product> Products { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }

        public string PaymentMethod { get; set; }

        public bool IsPaid = false;

        //DateTime.UtcNow;
        public DateTime CreatedAt { get; set; }

        public Order()
        {
        }

        public Order(Guid userId, Product product, int quantity)
        {
            UserId = userId;
            //Products = products ?? throw new Exception("Products cannot be null");
            Product = product;
            Quantity = quantity;
        }

        public override string ToString()
        {
            return $"{Id}, {Product.Name}, {Product.Price}, {Quantity}, paid: {IsPaid}";
        }
    }
}