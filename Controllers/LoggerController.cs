using Microsoft.AspNetCore.Mvc;
using MyApp.Models;
using System.Diagnostics;

namespace MyApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoggerController(ILogger<LoggerController> logger) : ControllerBase
    {
        [HttpGet("log")]
        public IActionResult LogMessage(string message)
        {
            logger.LogInformation("Logging message: {User}", message); // serilog based

            //logger.LogError("Error message: {Message}", message);

            //logger.LogTrace("Trace message: {Message}", message);

            logger.LogWarning($"Trace message: {message}"); // string based 

            //logger.LogDebug("Trace message: {Message}", message);

            return Ok("Message logged successfully.");
        }

        [HttpGet("metrics")]
        public IActionResult LogMetrics()
        {
            var stopwatch = Stopwatch.StartNew();

            var users = EmployeeData.Employees.Where(x => x.Salary > 20000).ToList(); //can be replaced with actual servcie call to get data from database or any other source

            stopwatch.Stop();
            
            logger.LogInformation("GetUsers endpoint took {ElapsedMs} ms", stopwatch.ElapsedMilliseconds);

            return Ok(users);
        }
    }
}
