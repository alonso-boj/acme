using ACME.Store.Domain.Models.Requests;
using FluentValidation;

namespace ACME.Store.Application.Validators;

public class RegisterCustomerRequestDtoValidator : AbstractValidator<RegisterCustomerRequest>
{
    public RegisterCustomerRequestDtoValidator()
    {
    }
}
