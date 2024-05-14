using FluentValidation;

namespace Demo_CapitalPlacement.Application.TodoItems.Commands.CreateTodo
{
    public class CreateTodoCommandValidator : AbstractValidator<CreateTodoCommand>
    {
        public CreateTodoCommandValidator()
        {
            RuleFor(x => x.Description).NotNull().NotEmpty().WithMessage("Job description cannot be empty");
            RuleFor(x => x.IsActive).NotNull()
            .NotEmpty().WithMessage("IsActive must not be empty.");
            RuleFor(x => x.RefrenceNumber).NotEmpty().NotNull().WithMessage("Refrence Id cannot be empty");
            RuleFor(x => x.ApplyDate).NotEmpty().NotNull().WithMessage("Apply date cannot be empty");
            RuleFor(x => x.Experience).NotEmpty().NotNull().WithMessage("Experience cannot be empty");
            RuleFor(x => x.TodoOptionsViews).NotNull().WithMessage("Todo options cannot be null");
        }
    }
}