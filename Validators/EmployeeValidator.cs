using FluentValidation;
using MyApp.Queries.Models;

namespace MyApp.Validators
{
    public class EmployeeValidator : AbstractValidator<Employee>
    {
        public EmployeeValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MinimumLength(3).WithMessage("Name must be at least 3 characters long.");

            RuleFor(x => x.Department)
                .NotEmpty().WithMessage("Department is required.")
                .Must(dept => dept == "IT" || dept == "HR").WithMessage("Department must be either 'IT' or 'HR'.");

            RuleFor(x => x.Salary)
                .GreaterThan(0).WithMessage("Salary must be greater than 0.")
                .LessThanOrEqualTo(100000).WithMessage("Salary must be less than or equal to 100000.");
        }
    }
}
