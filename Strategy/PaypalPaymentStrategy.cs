namespace MyApp.Strategy
{
    public class PaypalPaymentStrategy
    {
        public string Key => "paypal";
        public Task ProcessPayment(decimal amount)
        {
            Console.WriteLine($"Paypal payment: {amount}");
            return Task.CompletedTask;
        }
    }
}