using FluentValidation;

namespace Demo_CapitalPlacement.Application.TodoItems.Commands.DeleteTodo
{
    public class DeleteTodoValidator : AbstractValidator<DeleteTodoCommand>
    {
        public DeleteTodoValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id cannot be empty")
                              .NotNull().WithMessage("Id cannot be null")
                            .Must(BeNumericAndNonNegative).WithMessage("Id must be numeric and non-negative");
        }

        private bool BeNumericAndNonNegative(int id)
        {
            return id >= 0;
        }
    }
}
