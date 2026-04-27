using Microsoft.AspNetCore.Mvc;

namespace MyApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GarbageCollectionController : ControllerBase
    {
        [HttpGet("GarbageCollection")]
        public IActionResult GCDemo()
        {
            // Every new object is allocated in Gen0 (young generation)
            var obj = new object();

            // Check generation immediately after creation → should be Gen0
            int genBefore = GC.GetGeneration(obj);

            // 🔹 Step 2: Trigger Garbage Collection
            GC.Collect(0);
            GC.WaitForPendingFinalizers();

            // Second GC cycle:
            GC.Collect(1);

            // 🔹 Step 3: Check generation after GC
            int genAfter = GC.GetGeneration(obj);

            return Ok(new
            {
                Message = "GC Demo with Generations",
                GenerationBefore = genBefore, // Expected: 0 (Gen0)
                GenerationAfter = genAfter    // Expected: 1 or 2 depending on survival
            });
        }
    }
}