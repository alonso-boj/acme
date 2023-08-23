using ACME.Store.Domain.Constants;
using ACME.Store.Domain.Models.Requests;
using FluentValidation;

namespace ACME.Store.Application.Validators;

public class RegisterAddressRequestValidator : AbstractValidator<RegisterAddressRequest>
{
    public RegisterAddressRequestValidator()
    {
        ClassLevelCascadeMode = CascadeMode.Continue;

        RuleFor(request => request.Street)
            .NotEmpty()
            .WithMessage(ValidationErrorMessages.STREET_NOT_EMPTY)
            .Length(3, 128)
            .WithMessage(ValidationErrorMessages.STREET_LENGTH);

        RuleFor(request => request.Number)
            .NotEmpty()
            .WithMessage(ValidationErrorMessages.NUMBER_NOT_EMPTY);

        RuleFor(request => request.Complement)
            .NotNull()
            .WithMessage(ValidationErrorMessages.COMPLEMENT_NOT_NULL)
            .Length(3, 128)
            .WithMessage(ValidationErrorMessages.COMPLEMENT_LENGTH);

        RuleFor(request => request.Neighborhood)
            .NotEmpty()
            .WithMessage(ValidationErrorMessages.NEIGHBORHOOD_NOT_EMPTY)
            .Length(3, 128)
            .WithMessage(ValidationErrorMessages.NEIGHBORHOOD_LENGTH);

        RuleFor(request => request.City)
            .NotEmpty()
            .WithMessage(ValidationErrorMessages.CITY_NOT_EMPTY)
            .Length(3, 128)
            .WithMessage(ValidationErrorMessages.CITY_LENGTH);

        RuleFor(request => request.State)
            .NotEmpty()
            .WithMessage(ValidationErrorMessages.STATE_NOT_EMPTY)
            .Length(3, 64)
            .WithMessage(ValidationErrorMessages.STATE_LENGTH);

        RuleFor(request => request.ZipCode)
            .NotEmpty()
            .WithMessage(ValidationErrorMessages.ZIPCODE_NOT_EMPTY)
            .Length(8)
            .WithMessage(ValidationErrorMessages.ZIPCODE_LENGTH);
    }
}
