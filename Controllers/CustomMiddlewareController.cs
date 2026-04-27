using Microsoft.AspNetCore.Mvc;

namespace MyApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomMiddlewareController : ControllerBase
    {
        [HttpGet("middleware-test")]
        public IActionResult MiddlewareTest()
        {
            //throw new Exception("This is a test exception to demonstrate the global exception handling middleware.");

            return Ok("Custom Middleware Test Successful");
        }

        [HttpGet("exception-middleware")]
        public IActionResult ExceptionMiddleware()
        {

            throw new Exception { };

           // return Ok("Global exception middleware executed.");

        }
    }
}
