using Microsoft.AspNetCore.Mvc;
using MyApp.Interface;
using MyApp.Models;
using MyApp.Service;

namespace MyApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OOPSController : ControllerBase
    {
        /// <summary>
        /// Encapsulation: The BankAccount class encapsulates the balance and provides methods to deposit and get the 
        /// balance, hiding the internal implementation details from the user.
        /// </summary>
        /// <returns></returns>
        [HttpGet("encapsulation")]
        public IActionResult Encapsulation()
        {
            var account = new BankAccount();

            account.Deposit(500);
            var balance = account.GetBalance();

            return Ok($"Balance: {balance}");
        }

        /// <summary>
        /// Inheritance: The SavingsAccount class inherits from BankAccount, allowing it to reuse the deposit and balance functionality while
        /// adding its own method for adding interest, demonstrating inheritance in OOP.
        /// </summary>
        /// <returns></returns>
        [HttpGet("inheritance")]
        public IActionResult Inheritance()
        {
            var account = new SavingsAccount();

            account.Deposit(500);
            account.AddInterest();

            return Ok("Inheritance executed");
        }

        /// <summary>
        /// Abstraction: The IPaymentService interface defines a contract for payment services, and the CreditCardPayment class implements this interface,
        /// allowing us to use abstraction to hide the implementation details of the payment process.
        /// </summary>
        /// <returns></returns>
        [HttpGet("abstraction")]
        public IActionResult Abstraction()
        {
            IPaymentService payment = new CreditCardPaymentService();
            payment.Pay(1000);

            return Ok("Abstraction used");
        }

        /// <summary>
        /// Polymorphism: The Polymorphism method demonstrates polymorphism by using a switch expression to create an instance of either UpiPayment or
        /// CreditCardPayment based on the input type, allowing us to treat different payment types uniformly through the IPaymentService interface.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        [HttpGet("polymorphism")]
        public IActionResult Polymorphism(string type)
        {
            IPaymentService payment = type switch
            {
                "UPI" => new UpiPaymentService(),
                "Card" => new CreditCardPaymentService(),
                _ => throw new Exception("Invalid type")
            };

            payment.Pay(2000);

            return Ok("Polymorphism executed");
        }

        /// <summary>
        /// All OOP Principles Combined: This method demonstrates the combined use of all OOP principles. It creates a SavingsAccount (encapsulation + inheritance) and then uses a 
        /// switch expression to create a payment service (abstraction + polymorphism) based on the input type, showcasing how all OOP principles can work together in a single method.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        [HttpGet("all-principles")]
        public IActionResult Combined(string type)
        {
            // Encapsulation + Inheritance
            var account = new SavingsAccount();
            account.Deposit(1000);

            // Abstraction + Polymorphism
            IPaymentService payment = type switch
            {
                "UPI" => new UpiPaymentService(),
                "Card" => new CreditCardPaymentService(),
                _ => throw new Exception("Invalid type")
            };

            payment.Pay(500);

            return Ok("All OOP principles used");
        }
    }
}
