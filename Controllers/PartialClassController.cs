using Microsoft.AspNetCore.Mvc;
using MyApp.Models;

namespace MyApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartialClassController : ControllerBase
    {
        EmployeePartial employeePartial = new EmployeePartial();

        [HttpGet("partial-class")]
        public IActionResult PartialClassCheck()
        {
            var result = employeePartial.Name = "Praduman";
            
            var result1 = employeePartial.DeptId = 1;
           
            return Ok(result + ' ' + result1);
        }
    }
}
