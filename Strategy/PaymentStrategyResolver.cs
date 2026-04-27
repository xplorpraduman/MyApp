using MyApp.Interface;

namespace MyApp.Strategy
{
    public class PaymentStrategyResolver
    {
        private readonly IEnumerable<IPaymentStrategy> _strategies;

        public PaymentStrategyResolver(IEnumerable<IPaymentStrategy> strategies)
        {
            _strategies = strategies;
        }

        public IPaymentStrategy Resolve(string key)
        {
            var strategy = _strategies.FirstOrDefault(
                s => s.Key.Equals(key, StringComparison.OrdinalIgnoreCase));

            if (strategy == null)
                throw new Exception($"No strategy found for key: {key}");

            return strategy;
        }
    }
}
