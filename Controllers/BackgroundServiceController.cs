using Microsoft.AspNetCore.Mvc;
using MyApp.Service;

namespace MyApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BackgroundServiceController(WorkerState workerState) : ControllerBase
    {
        [HttpGet("status")]
        public IActionResult GetStatus()
        {
            return Ok(new { workerState.IsRunning });
        }
    }
}