using ACME.Store.Domain.Dtos.Requests;
using ACME.Store.Domain.Interfaces.Services;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ACME.Store.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomerController : StandardController
{
    private readonly IValidator<RegisterCustomerRequestDto> _validator;
    private readonly ICustomerService _customerService;

    public CustomerController(
        IValidator<RegisterCustomerRequestDto> validator,
        ICustomerService customerService)
    {
        _validator = validator;
        _customerService = customerService;
    }

    [HttpPost("register")]
    [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status422UnprocessableEntity)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> RegisterCustomerAsync([FromBody] RegisterCustomerRequestDto request)
    {
        var validationResult = await _validator.ValidateAsync(request);

        if (!validationResult.IsValid)
        {
            ValidationProblemDetails validationProblemDetails = GetValidationProblemDetails(validationResult);

            return UnprocessableEntity(validationProblemDetails);
        }

        await _customerService.RegisterCustomerAsync(request);

        return Ok();
    }
}
