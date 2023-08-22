using ACME.Store.Domain.Models.Requests;
using FluentValidation;

namespace ACME.Store.Application.Validators;

public class RegisterCustomerRequestValidator : AbstractValidator<RegisterCustomerRequest>
{
    public RegisterCustomerRequestValidator()
    {
        ClassLevelCascadeMode = CascadeMode.Continue;

        RuleFor(request => request.Name)
            .NotEmpty()
            .WithMessage("Name cannot be empty or null")
            .Length(3, 128)
            .WithMessage("Name must be between 3 and 128 characters");

        RuleFor(request => request.Phone)
            .NotEmpty()
            .WithMessage("Phone cannot be empty or null")
            .Length(11)
            .WithMessage("Phone must be exactly 11 characters");

        RuleFor(request => request.Mail)
            .NotEmpty()
            .WithMessage("Mail cannot be empty or null")
            .EmailAddress()
            .WithMessage("Mail must be a valid e-mail address");
    }
}
