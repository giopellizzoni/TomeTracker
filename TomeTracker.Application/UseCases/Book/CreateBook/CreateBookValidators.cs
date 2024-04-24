using FluentValidation;

using TomeTracker.Application.UseCases.Book.Models;

namespace TomeTracker.Application.UseCases.Book.CreateBook;

public class CreateBookValidators : AbstractValidator<BookRequest>
{
    public CreateBookValidators()
    {
        RuleFor(b => b.Title)
            .MaximumLength(60)
            .NotNull()
            .NotEmpty()
            .WithMessage("Title can't be null or empty");

        RuleFor(b => b.Author)
            .MaximumLength(50)
            .NotNull()
            .NotEmpty()
            .WithMessage("Author can't be null or empty");

        RuleFor(b => b.ISBN)
            .NotNull()
            .NotEmpty()
            .WithMessage("ISBN can't be null or empty");

        RuleFor(b => b.PublishingYear)
            .NotEmpty()
            .WithMessage("Publishing Year Invalid");

        RuleFor(b => b.PublishingYear)
            .LessThan(DateTime.Now.Year)
            .WithMessage("Can't add a book that will be published in the future");
    }
}
