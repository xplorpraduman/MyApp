namespace MyApp.Interface
{
    public interface IPaymentStrategy
    {
        string Key { get; }
        Task ProcessPayment(decimal amount);
    }
}
