using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace MyApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RateLimitingController : ControllerBase
    {
        [HttpGet("rate-limiter")]
        [EnableRateLimiting("fixed")]
        public IActionResult Get()
        {
            return Ok("This endpoint is rate limited with a fixed window policy.");
        }
    }
}