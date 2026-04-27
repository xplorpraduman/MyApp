namespace MyApp.Interface
{
    public interface IPaymentStrategyResolver
    {
        IPaymentStrategy Resolve(string key);
    }
}