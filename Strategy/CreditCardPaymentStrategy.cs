namespace MyApp.Strategy
{
    public class CreditCardPaymentStrategy
    {
        public string Key => "creditcard";
        public Task ProcessPayment(decimal amount)
        {
            Console.WriteLine($"Credit Card payment: {amount}");
            return Task.CompletedTask;
        }
    }
}
