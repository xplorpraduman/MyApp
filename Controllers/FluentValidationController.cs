using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using MyApp.Queries.Models;

namespace MyApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FluentValidationController (IValidator <Employee> validator) : ControllerBase
    {
        [HttpPost("validateEmployee")]
        public IActionResult ValidateEmployee(Employee employee)
        {
            var validationResult = validator.Validate(employee);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors.Select(x => new
                {
                    Error = x.ErrorMessage
                }));
            }

            return Ok("Employee data is valid.");
        }

    }
}
