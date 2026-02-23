namespace CW10.Service.payments
{
    public class OnlinePayment : Payment
    {
        public string CorelationId { get; set; }

        public OnlinePayment(Guid orderId, decimal amount) : base(orderId, amount)
        {
        }

        public override void Pay()
        {
            PaidAt = DateTime.UtcNow;
            CorelationId = Guid.NewGuid().ToString();
        }

        public override string MethodName()
        {
            return "onlinePayment";
        }
    }
}