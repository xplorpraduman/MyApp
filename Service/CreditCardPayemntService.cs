using MyApp.Interface;

namespace MyApp.Service
{
    public class CreditCardPaymentService : IPaymentService
    {
        public void Pay(decimal amount)
        {
            Console.WriteLine($"Paid {amount} using Credit Card");
        }
    }
}
