using Microsoft.AspNetCore.Mvc;
using MyApp.Extensions;
using MyApp.Models;

namespace MyApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExtensionController : ControllerBase
    {
        [HttpPost("extension-method")]
        public IActionResult ModifyUser(ExtensionField extensionField)
        {
            var result = extensionField.ToUpperName(); // Using the extension method to modify the string

            return Ok(result);
        }
    }
}
