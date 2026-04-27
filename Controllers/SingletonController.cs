using Microsoft.AspNetCore.Mvc;
using MyApp.Singleton;

namespace MyApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SingletonController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            LoggerSingleton.Instance.Log("Hello Singleton");

            return Ok("Logged Successfully");
        }
    }
}
