namespace CW10.Model
{
    public class Product
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int Stock { get; set; }

        public Product()
        {
        }

        public Product(string name, decimal price, int stock)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Invalid product name.");
            if (price <= 0) throw new ArgumentException("Price must be greater than 0.");
            if (stock < 0) throw new ArgumentException("Stock cannot be negative.");

            Name = name.Trim();
            Price = price;
            Stock = stock;
        }

        public void SetStock(int stock)
        {
            if (stock < 0) throw new ArgumentException("Stock cannot be negative.");
            Stock = stock;
        }

        public void DecreaseStock(int quantity)
        {
            ValidateQuantity(quantity, true);
            Stock -= quantity;
        }

        public void IncreaseStock(int quantity)
        {
            ValidateQuantity(quantity, false);
            Stock += quantity;
        }

        private void ValidateQuantity(int quantity, bool isDecrese)
        {
            if (quantity <= 0) throw new ArgumentException("Quantity must be greater than 0.");
            if (isDecrese)
            {
                if (quantity > Stock) throw new InvalidOperationException("Not enough stock.");
            }
        }
    }
}