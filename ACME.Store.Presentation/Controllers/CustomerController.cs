using ACME.Store.Domain.Interfaces.Services;
using ACME.Store.Domain.Models.Requests;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ACME.Store.Presentation.Controllers;

[ApiController]
[Route("api")]
public class CustomerController : StandardController
{
    private readonly IValidator<RegisterCustomerRequest> _validator;
    private readonly ICustomerService _customerService;

    public CustomerController(
        IValidator<RegisterCustomerRequest> validator,
        ICustomerService customerService)
    {
        _validator = validator;
        _customerService = customerService;
    }

    [HttpPost($"customer/register")]
    [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status422UnprocessableEntity)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> RegisterCustomerAsync([FromBody] RegisterCustomerRequest request)
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

    [HttpGet("customer/details/{id}")]
    [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status422UnprocessableEntity)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetCustomerDetailsAsync([FromRoute] Guid id)
    {
        var customerDetails = await _customerService.GetCustomerDetails(id);

        return Ok(customerDetails);
    }

    [HttpGet("customers")]
    [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status422UnprocessableEntity)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetAllCustomersAsync()
    {
        var customers = await _customerService.GetAllCustomers();

        return Ok(customers);
    }
}
