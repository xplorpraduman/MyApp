using MyApp.Queries.Models;

namespace MyApp.Models
{
    public class DepartmentData
    {
        public static List<Department> Departments = new List<Department>
        {
            new Department { Name = "IT", Location = "Pune" },
            new Department { Name = "HR", Location = "Mumbai" },
            new Department { Name = "Finance", Location = "Delhi" }
        };
    }
}
