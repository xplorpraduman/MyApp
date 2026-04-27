using Microsoft.AspNetCore.Mvc;
using MyApp.Models;
using MyApp.Queries.Models;
using System.Linq;

namespace MyApp.Controllers
{
    [ApiController]
    [Route("linq")]
    public class LinqPracticeController : ControllerBase
    {
       [HttpGet("high-salary")]
        public IActionResult GetHighSalary()
        {
            var result = EmployeeData.Employees.Where(e => e.Salary > 50000);
            return Ok(result);
        }

        [HttpGet("sorted")]
        public IActionResult GetSorted()
        {
            var result = EmployeeData.Employees.OrderByDescending(e => e.Salary);
            return Ok(result);
        }

        [HttpGet("group-by-department")]
        public IActionResult GroupByDepartment()
        {
            var result = EmployeeData.Employees
                .GroupBy(e => e.Department)
                .Select(g => new
                {
                    Department = g.Key,
                    Count = g.Count(),
                    AvgSalary = g.Average(x => x.Salary)
                });

            return Ok(result);
        }

        [HttpGet("first-it")]
        public IActionResult GetFirstIT()
        {
            var result = EmployeeData.Employees.FirstOrDefault(e => e.Department == "IT");

            // var result =  EmployeeData.Employees.SingleOrDefault(e => e.Department == "IT"); //Error

            return Ok(result);
        }

        [HttpGet("any-high-salary")]
        public IActionResult AnyHighSalary()
        {
            var result = EmployeeData.Employees.Any(e => e.Salary > 65000); // will return boolean value
            return Ok(result);
        }

        [HttpGet("aggregates")]
        public IActionResult GetAggregates()
        {
            var result = new
            {
                Total = EmployeeData.Employees.Sum(e => e.Salary),
                Average = EmployeeData.Employees.Average(e => e.Salary),
                Max = EmployeeData.Employees.Max(e => e.Salary)
            };

            return Ok(result);
        }

        [HttpGet("join")]
        public IActionResult JoinEmployeeDepartment()
        {
            var result =  EmployeeData.Employees.Join(DepartmentData.Departments, emp => emp.Department, dept => dept.Name,
                (emp, dept) => new
                {
                    emp.Name,
                    emp.Salary,
                    dept.Location
                });

            return Ok(result);
        }

        [HttpGet("pagination")]
        public IActionResult Pagination()
        {
            var result =  EmployeeData.Employees
                .OrderBy(e => e.Id)
                .Skip(2)
                .Take(2);

            return Ok(result);
        }

        [HttpGet("distinct-departments")]
        public IActionResult DistinctDepartments()
        {
            var result =  EmployeeData.Employees
                .Select(e => e.Department)
                .Distinct();

            return Ok(result);
        }

        [HttpGet("kth-highest")]
        public IActionResult kthHighest(int k)
        {
            var result =  EmployeeData.Employees
                .Select(e => e.Salary)
                .Distinct()
                .OrderByDescending(s => s)
                .Skip(k - 1)
                .FirstOrDefault();

            return Ok(result);
        }

        [HttpGet("remove-duplicate-name")]
        public IActionResult RemoveDuplicateName()
        {
            var result =  EmployeeData.Employees.DistinctBy(e => e.Department).ToList(); // Remove duplicate name based on all properties

            return Ok(result);
        }

        [HttpGet("duplicate- EmployeeData.Employees")]
        public IActionResult DeuplicateEmployees()
        {
            var result =  EmployeeData.Employees.GroupBy(g => g.Name).Where(g => g.Count() > 1).Select(g => g);

            return Ok(result);
        }

        [HttpGet("remove- EmployeeData.Employees")]
        public IActionResult RemoveEmployees()
        {
            var emp =  EmployeeData.Employees.First(e => e.Name == "John");

            EmployeeData.Employees.Remove(emp);

            return Ok(EmployeeData.Employees);
        }

        [HttpGet("remove-multiple-names")]
        public IActionResult RemoveMultipleEmployees()
        {
            var namesToRemove = new List<string> { "John", "Alice" };

             EmployeeData.Employees.RemoveAll(e => namesToRemove.Contains(e.Name));

            return Ok( EmployeeData.Employees);
        }

        [HttpGet("same-salary")]
        public IActionResult SameSalary()
        {
            var result =  EmployeeData.Employees
                        .GroupBy(e => e.Salary)
                        .Where(g => g.Count() > 1)
                        .SelectMany(g => g)
                        .Select(e => new { e.Name, e.Salary });

            return Ok(result);
        }

        [HttpGet("employee-not-in-any-department")]
        public IActionResult NoDepartment()
        {
            var result =  EmployeeData.Employees.Where(g => g.Department == null).Select(e => e.Name);

            return Ok(result);
        }

        [HttpGet("dept-with-highest-salary")]
        public IActionResult DeptWithHighestSalary()
        {
            var result =  EmployeeData.Employees
                         .OrderByDescending(e => e.Salary)
                         .Select(e => new { e.Name, e.Salary })
                         .FirstOrDefault();

            return Ok(result);
        }
    }
}