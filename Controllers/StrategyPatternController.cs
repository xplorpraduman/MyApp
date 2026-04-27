using Microsoft.AspNetCore.Mvc;
using MyApp.Interface;
using MyApp.Models;
using MyApp.Service;

namespace MyApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StrategyPatternController(PaymentService  paymentService) : ControllerBase
    {
        [HttpPost("strategy")]
        public async Task<IActionResult> ProcessPayment([FromBody] PaymentRequest request)
        {
            await paymentService.ProcessPayment(request);

            return Ok();
        }
    }
}
