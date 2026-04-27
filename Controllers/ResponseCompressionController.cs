using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyApp.Models;
using System.IO.Compression;
using System.Text;
using System.Text.Json;

namespace MyApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResponseCompressionController : ControllerBase
    {
        [HttpGet("compressed-response")]
        
        public async Task<IActionResult> GetCompressedRespone()
        {
            var employeeData = EmployeeData.Employees;

            var json = JsonSerializer.Serialize(employeeData);
            var bytes = Encoding.UTF8.GetBytes(json);

            var memoryStream  = new MemoryStream();

            using(var gzip = new GZipStream(memoryStream, CompressionLevel.Fastest, true))
            {
                await gzip.WriteAsync(bytes, 0, bytes.Length);
            }

            memoryStream.Position = 0;

            Response.Headers["Content-Encoding"] = "gzip";
            Response.Headers["Content-Type"] = "application/json";


            return File(memoryStream, "application/json");
        }
    }
}
