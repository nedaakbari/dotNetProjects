namespace CW10.Service.payments
{
    public sealed class CardPayment : Payment
    {
        public string CardNumber { get; }

        public CardPayment(Guid orderId, decimal amount, string cardNumber) : base(orderId, amount)
        {
            if (string.IsNullOrWhiteSpace(cardNumber)) throw new ArgumentException("Card number is required.");
            if (cardNumber.Length < 12) throw new ArgumentException("Invalid card number.");
            CardNumber = cardNumber;
        }

        public override void Pay()
        {
            PaidAt = DateTime.Now;
        }

        public override string MethodName()
        {
            return "CardPayment";
        }
    }
}