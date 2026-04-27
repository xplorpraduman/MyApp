using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyApp.Interface;
using MyApp.Models;
using MyApp.Service;

namespace MyApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SOLIDPrincipleController : ControllerBase
    {
        /// <summary>
        /// Single Responsibility Principle (SRP): A class should have only one reason to change. In this example, OrderService is responsible only for order-related operations, adhering to SRP.
        /// </summary>
        /// <returns></returns>
        [HttpPost("srp")]
        [Authorize]
        public IActionResult SRP()
        {
            var order = new Order { Id = 1, Amount = 500 };

            var orderService = new OrderService();
            orderService.CreateOrder(order);

            return Ok("SRP followed");
        }

        /// <summary>
        /// Open closed principle (OCP): Software entities (classes, modules, functions, etc.) should be open for extension but closed for modification. In this example, we can add new payment methods without modifying existing code, adhering to OCP.
        /// </summary>
        /// <returns></returns>
        [HttpPost("ocp")]
        [Authorize]
        public IActionResult OCP()
        {
            IPaymentService payment = new CreditCardPaymentService();
            payment.Pay(1000);

            return Ok("OCP followed");
        }

        /// <summary>
        /// Liskov Substitution Principle (LSP): Objects of a superclass should be replaceable with objects of a subclass without affecting the correctness of the program. In this example, we can replace CreditCardPayment with UpiPayment without breaking the code, adhering to LSP.
        /// </summary>
        /// <returns></returns>
        [HttpPost("lsp")]
        [Authorize]
        public IActionResult LSP()
        {
            //UpiPayment payment = new UpiPayment(); // Tight coupled to UpiPayment, not adhering to LSP
            IPaymentService payment = new UpiPaymentService(); // swapped

            payment.Pay(2000);

            return Ok("LSP followed");
        }

        /// <summary>
        /// Interface Segregation Principle (ISP): Clients should not be forced to depend on interfaces they do not use. In this example, we have a separate IPrinter interface for printing, adhering to ISP.
        /// </summary>
        /// <returns></returns>
        [HttpGet("isp")]
        [Authorize]
        public IActionResult ISP()
        {
            IPrinter printer = new Printer();
            printer.Print();

            return Ok("ISP followed");
        }

        /// <summary>
        /// Dependency Inversion Principle (DIP): High-level modules should not depend on low-level modules. Both should depend on abstractions. In this example, OrderServiceDIP depends on the abstraction IPaymentService rather than a concrete implementation, adhering to DIP.
        /// </summary>
        /// <returns></returns>
        [HttpPost("dip")]
        [Authorize]
        public IActionResult DIP()
        {
            IPaymentService payment = new CreditCardPaymentService();

            var orderService = new OrderServiceDIP(payment);
            orderService.PlaceOrder(1500);

            return Ok("DIP followed");
        }

    }
}
