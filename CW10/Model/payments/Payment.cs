namespace CW10.Service.payments
{
    public abstract class Payment
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid OrderId { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaidAt { get; set; }

        protected Payment(Guid orderId, decimal amount)
        {
            if (orderId == Guid.Empty) throw new ArgumentException("OrderId cannot be empty.");
            if (amount <= 0) throw new ArgumentException("Amount must be greater than 0.");
            OrderId = orderId;
            Amount = amount;
        }

        public abstract void Pay();
        public abstract string MethodName();
    }
}