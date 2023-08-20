using ACME.Store.Domain.Dtos.Requests;
using FluentValidation;

namespace ACME.Store.Application.Validators;

public class RegisterCustomerRequestDtoValidator : AbstractValidator<RegisterCustomerRequestDto>
{
    public RegisterCustomerRequestDtoValidator()
    {
    }
}
