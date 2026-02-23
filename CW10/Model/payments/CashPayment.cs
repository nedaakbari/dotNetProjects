using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CW10.Service.payments
{
    public class CashPayment : Payment
    {
        public CashPayment(Guid orderId, decimal amount) : base(orderId, amount)
        {
        }

        public override void Pay()
        {
            PaidAt = DateTime.UtcNow;
        }

        public override string MethodName()
        {
            return "CashPayment";
        }
    }

}
