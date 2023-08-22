using ACME.Store.Domain.Models.Requests;
using FluentValidation;

namespace ACME.Store.Application.Validators;

public class RegisterAddressRequestValidator : AbstractValidator<RegisterAddressRequest>
{
    public RegisterAddressRequestValidator()
    {
        ClassLevelCascadeMode = CascadeMode.Continue;

        RuleFor(request => request.Main)
            .NotNull()
            .WithMessage("Main cannot be null");

        RuleFor(request => request.Street)
            .NotEmpty()
            .WithMessage("Street cannot be empty or null")
            .Length(3, 128)
            .WithMessage("Street must be between 3 and 128 characters");

        RuleFor(request => request.Number)
            .NotEmpty()
            .WithMessage("Number cannot be null or zero");

        RuleFor(request => request.Complement)
            .NotNull()
            .WithMessage("Complement cannot be null")
            .Length(3, 128)
            .WithMessage("Complement must be between 3 and 128 characters");

        RuleFor(request => request.City)
            .NotEmpty()
            .WithMessage("City cannot be empty or null")
            .Length(3, 128)
            .WithMessage("City must be between 3 and 128 characters");

        RuleFor(request => request.State)
            .NotEmpty()
            .WithMessage("State cannot be empty or null")
            .Length(3, 64)
            .WithMessage("State must be between 3 and 64 characters");

        RuleFor(request => request.ZipCode)
            .NotEmpty()
            .WithMessage("ZipCode cannot be null or zero")
            .Length(8)
            .WithMessage("ZipCode must be exactly 8 characters");

        RuleFor(request => request.CustomerId.ToString())
            .NotEmpty()
            .WithMessage("CustomerId cannot be empty or null")
            .Length(36)
            .WithMessage("CustomerId must be exactly 36 characters");
    }
}
