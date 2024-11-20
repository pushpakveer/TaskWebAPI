using FluentValidation;
using System.Linq;
using TaskWebAPI.Models;
using Task = TaskWebAPI.Models.Task;

namespace TaskWebAPI.Validations
{
    public class TaskValidator:AbstractValidator<Task>
    {
        public TaskValidator()
        {
            // Id must be greater than 0
            RuleFor(task => task.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0.");

            // Title is required and must not exceed 100 characters
            RuleFor(task => task.Title)
                .NotEmpty().WithMessage("Title is required.")
                .MaximumLength(100).WithMessage("Title must not exceed 100 characters.");

            // Description must not exceed 500 characters
            RuleFor(task => task.Description)
                .MaximumLength(500).WithMessage("Description must not exceed 500 characters.");

            // Status must be one of the predefined values from enums
            RuleFor(task => task.Status)
                .NotEmpty().WithMessage("Status is required.")
                .Must(status => new[] { "Pending", "In_Progress", "Completed" }.Contains(status))
                .WithMessage("Status must be 'Pending', 'In_Progress', or 'Completed'.");

            // Due_Date must be current date or greater than it
            RuleFor(task => task.Due_Date)
                .GreaterThanOrEqualTo(DateOnly.FromDateTime(DateTime.Now))
                .WithMessage("Due date must be today or later.");
        }

    }
}
