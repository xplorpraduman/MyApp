using MyApp.Queries.Models;

namespace MyApp.Models
{
    public class EmployeeData
    {
        public static List<Employee> Employees = new List<Employee>
        {
            new Employee { Id = 1, Name = "John", Department = "ITI", Salary = 50000 },
            new Employee { Id = 2, Name = "Alice", Department = "HR1", Salary = 40000 },
            new Employee { Id = 3, Name = "Bob", Department = "IT", Salary = 10000 },
            new Employee { Id = 4, Name = "John", Department = null, Salary = 70000 },
            new Employee { Id = 5, Name = "Emma", Department = "HR", Salary = 45000 }
        };
    }
}