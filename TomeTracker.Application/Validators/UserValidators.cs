using FluentValidation;

using TomeTracker.Application.UseCases.User.Commands;

namespace TomeTracker.Application.Validators;

public class UserValidators: AbstractValidator<CreateUserRequest>
{
    public UserValidators()
    {
        RuleFor(u => u.Email)
            .EmailAddress()
            .WithMessage("Invalid Email");

        RuleFor(u => u.Name)
            .NotNull()
            .NotEmpty()
            .WithMessage("Name is Mandatory");

    }
}
