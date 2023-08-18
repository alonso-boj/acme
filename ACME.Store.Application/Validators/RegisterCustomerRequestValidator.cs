using ACME.Store.Domain.Models.Requests;
using FluentValidation;

namespace ACME.Store.Application.Validators;

public class RegisterCustomerRequestValidator : AbstractValidator<RegisterCustomerRequest>
{
    public RegisterCustomerRequestValidator()
    {
        RuleFor(request => request.Name)
            .NotEmpty()
            .WithMessage("Name cannot be empty");

        RuleFor(request => request.Age)
            .NotEmpty()
            .WithMessage("Age cannot be zero or empty");
    }
}
