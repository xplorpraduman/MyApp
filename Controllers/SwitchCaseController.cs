using Microsoft.AspNetCore.Mvc;

namespace MyApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SwitchCaseController() : ControllerBase
    {

        [HttpGet("switch")]
        public IActionResult SwitchCase(string type)
        {
            var result = type?.Length switch
            {
                <= 3 => "Type UPI selected",
                >= 4 => "Type Card selected",
                _ => "Unknown type"
            };

            return Ok(result);
        }
    }
}
