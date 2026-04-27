using MyApp.Interface;

namespace MyApp.Service
{
    public class UpiPaymentService : IPaymentService
    {
        public void Pay(decimal amount)
        {
            Console.WriteLine($"Paid {amount} using UPI");
        }
    }
}
