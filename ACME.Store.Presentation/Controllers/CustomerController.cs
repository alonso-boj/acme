using ACME.Store.Domain.Interfaces.Services;
using ACME.Store.Domain.Models.Requests;
using ACME.Store.Domain.Models.Responses;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ACME.Store.Presentation.Controllers;

[ApiController]
[Route("api")]
public class CustomerController : StandardController
{
    private readonly ICustomerService _customerService;
    private readonly IValidator<RegisterCustomerRequest> _registerCustomerRequestValidator;

    public CustomerController(
        ICustomerService customerService,
        IValidator<RegisterCustomerRequest> registerCustomerRequestValidator)
    {
        _customerService = customerService;
        _registerCustomerRequestValidator = registerCustomerRequestValidator;
    }

    [HttpPost("customer/registration")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status422UnprocessableEntity)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> RegisterCustomerAsync([FromBody] RegisterCustomerRequest request)
    {
        var validationResult = await _registerCustomerRequestValidator.ValidateAsync(request);

        if (!validationResult.IsValid)
        {
            ValidationProblemDetails validationProblemDetails = GetValidationProblemDetails(validationResult);

            return UnprocessableEntity(validationProblemDetails);
        }

        var result = await _customerService.RegisterCustomerAsync(request);

        return new ObjectResult(new { Id = result.Value })
        {
            StatusCode = StatusCodes.Status201Created
        };
    }

    [HttpGet("customer/details/{id}")]
    [ProducesResponseType(typeof(GetCustomerDetailsResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetCustomerDetailsAsync([FromRoute] Guid id)
    {
        var result = await _customerService.GetCustomerDetails(id);

        return Ok(result.Value);
    }

    [HttpGet("customers")]
    [ProducesResponseType(typeof(IEnumerable<CustomerResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetAllCustomersAsync()
    {
        var result = await _customerService.GetAllCustomers();

        return Ok(result.Value);
    }
}
