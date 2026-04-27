namespace MyApp.Strategy
{
    public class UpiPaymentStrategy
    {
        public string Key => "upi";
        public Task ProcessPayment(decimal amount)
        {
            Console.WriteLine($"UPI payment: {amount}");
            return Task.CompletedTask;
        }
    }
}
