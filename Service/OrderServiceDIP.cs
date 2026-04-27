using MyApp.Interface;

namespace MyApp.Service
{
    public class OrderServiceDIP
    {
        private readonly IPaymentService _payment;

        public OrderServiceDIP(IPaymentService payment)
        {
            _payment = payment;
        }

        public void PlaceOrder(decimal amount)
        {
            _payment.Pay(amount);
        }
    }
}

