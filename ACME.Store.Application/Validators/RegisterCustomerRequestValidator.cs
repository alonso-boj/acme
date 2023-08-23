using ACME.Store.Domain.Constants;
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
            .WithMessage(ValidationErrorMessages.NAME_NOT_EMPTY)
            .Length(3, 128)
            .WithMessage(ValidationErrorMessages.NAME_LENGTH);

        RuleFor(request => request.Phone)
            .NotEmpty()
            .WithMessage(ValidationErrorMessages.PHONE_NOT_EMPTY)
            .Length(11)
            .WithMessage(ValidationErrorMessages.PHONE_LENGTH);

        RuleFor(request => request.Mail)
            .NotEmpty()
            .WithMessage(ValidationErrorMessages.MAIL_NOT_EMPTY)
            .EmailAddress()
            .WithMessage(ValidationErrorMessages.INVALID_MAIL);
    }
}
