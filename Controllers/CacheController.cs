using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using MyApp.Models;
using MyApp.Queries.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace MyApp.Controllers
{
    public class CacheController(IMemoryCache _memoryCache, IDistributedCache _distributedCache) : ControllerBase
    {
        /// <summary>
        /// Imemory cache 
        /// </summary>
        /// <returns></returns>
        [HttpGet("iMemory")]
        [Authorize (Roles = "HR")]
        public IActionResult IMemoryCaching([Required] int Id)
        {
            string cacheKey = "User_" + Id;

            if (!_memoryCache.TryGetValue(cacheKey, out Employee? emp))
            {
                emp = EmployeeData.Employees.FirstOrDefault(employees => employees.Id == Id);

                if (emp == null)
                    return NotFound();

                _memoryCache.Set(cacheKey, emp, TimeSpan.FromMinutes(5));
            }
            return Ok(emp);
        }

        /// <summary>
        /// Idistributed cache 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        /// 
        [Authorize(Roles = "Admin")]
        [HttpGet("iDistributed")]
        public IActionResult IDistributedCaching([Required] int Id)
        {
            string cacheKey = "User_" + Id;
            Employee? emp;
            
            var cacheData = _distributedCache.GetString(cacheKey);

            if (string.IsNullOrEmpty(cacheData))
            {
                emp = EmployeeData.Employees.FirstOrDefault(employees => employees.Id == Id);

                if (emp == null)
                    return NotFound();

                cacheData = JsonSerializer.Serialize(emp);

                _distributedCache.SetString(cacheKey, cacheData, new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5)
                });
            }
            else
            {
                emp = JsonSerializer.Deserialize<Employee>(cacheData);
            }
            return Ok(emp);
        }
    }
}
