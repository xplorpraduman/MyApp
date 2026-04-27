using MyApp.Interface;
using MyApp.Models;

namespace MyApp.Service
{
    public class PaymentService
    {
        private readonly IPaymentStrategyResolver _resolver;

        public PaymentService(IPaymentStrategyResolver resolver)
        {
            _resolver = resolver;
        }

        public async Task ProcessPayment(PaymentRequest request)
        {
            var strategy = _resolver.Resolve(request.PaymentType);

            await strategy.ProcessPayment(request.Amount);
        }
    }
}
