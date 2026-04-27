using Microsoft.AspNetCore.Mvc;
using MyApp.Service;
using System.ComponentModel.DataAnnotations;

namespace MyApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DelegateController(DelegateService delegateService) : ControllerBase
    {
        public delegate string GreetingDelegate(string name);

        [HttpGet("custom-delegate")]
        public IActionResult CustomDelegate([Required] string name, bool isMorning)
        {
            GreetingDelegate del;

            //var result = isMorning ? delegateService.SayMorning(name)
            //    : delegateService.SayEvening(name);

            if (isMorning)
            {
                del = delegateService.SayMorning;
            }
            else
            {
                del = delegateService.SayEvening;
            }
            var result = del(name);   // now del can be used anywhere like LogMethod, CacheMethod etc.

            return Ok(result);
        }

        [HttpGet("func")]
        public ActionResult FunDelegate(int a, int b)
        {
            Func<int, int, int> addFunc = delegateService.Add;

            var result = addFunc(a, b);

            return Ok(result);
        }

        [HttpGet("predicate")]
        public ActionResult PredicateDeligate(int age)
        {
            Predicate<int> predicate = delegateService.IsAdult;

            var result = predicate(age);

            return Ok("Does User is Adult? = " + result);
        }

        [HttpGet("actions")]
        public ActionResult ActionsDelegate(string log)
        {
            Action<string> action = delegateService.LogMessage;

            action(log);

            return Ok("Message logged successfully");
        }

        [HttpGet("multicast")]
        public IActionResult MulticastDelegate(string name)
        {
            GreetingDelegate del = delegateService.SayMorning;
            del += delegateService.SayEvening;

            var result = del(name); // Both methods will be called, but only the result of the last method (SayEvening) will be returned.

            return Ok(result);
        }
    }
}