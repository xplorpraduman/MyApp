using Microsoft.AspNetCore.Mvc;
using MyApp.Interface;
using MyApp.Service;

namespace MyApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DependencyInjectionController(CreditCardPaymentService creditCardPayment) : ControllerBase // Constructor Injection
    {
       
        [FromServices]
        public Printer printer { get; set; }



        [HttpGet("construtor-injection")]
        public IActionResult CreditCardPayment()
        {
            creditCardPayment.Pay(100);

            return Ok("Payment processed successfully through constructor injection");
        }



        [HttpGet("method-injection")]
        public IActionResult UPIPayment([FromServices] UpiPaymentService upiPayment)
        {
            upiPayment.Pay(150);

            return Ok("Payment processed successfully thorugh method injection");
        }



        [HttpGet("property-injection")]
        public IActionResult Print()
        {
            printer.Print();

            return Ok("Message printed successfully through property injection");
        }
    }    
}