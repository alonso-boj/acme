using ACME.Store.Domain.Interfaces.Services;
using ACME.Store.Domain.Models.Requests;
using ACME.Store.Domain.Models.Responses;
using Ardalis.Result;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ACME.Store.Presentation.Controllers;

[ApiController]
[Route("api")]
[Consumes("application/json")]
[Produces("application/json")]
public class CustomerController : StandardController
{
    private readonly ICustomerService _customerService;
    private readonly IValidator<RegisterCustomerRequest> _validator;

    public CustomerController(
        ICustomerService customerService,
        IValidator<RegisterCustomerRequest> validator)
    {
        _customerService = customerService;
        _validator = validator;
    }

    /// <summary>
    /// Route in charge of registering a customer.
    /// </summary>
    /// <param name="request">Register customer request.</param>
    [HttpPost("customer/registration")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status422UnprocessableEntity)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> RegisterCustomerAsync([FromBody] RegisterCustomerRequest request)
    {
        var validationResult = await _validator.ValidateAsync(request);

        if (!validationResult.IsValid)
        {
            var validationProblemDetails = GetValidationProblemDetails(validationResult);

            return UnprocessableEntity(validationProblemDetails);
        }

        var result = await _customerService.RegisterCustomerAsync(request);

        return new ObjectResult(new { Id = result.Value })
        {
            StatusCode = StatusCodes.Status201Created
        };
    }

    /// <summary>
    /// Route in charge of retrieving customer details information.
    /// </summary>
    /// <param name="id">Customer id.</param>
    [HttpGet("customer/details/{id}")]
    [ProducesResponseType(typeof(GetCustomerDetailsResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetCustomerDetailsAsync([FromRoute] Guid id)
    {
        var result = await _customerService.GetCustomerDetailsAsync(id);

        if (result.Status == ResultStatus.NotFound)
        {
            return NotFound(new { Error = result.Errors.First() });
        }

        return Ok(result.Value);
    }

    /// <summary>
    /// Route in charge of retrieving all customers.
    /// </summary>
    [HttpGet("customers")]
    [ProducesResponseType(typeof(IEnumerable<CustomerResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetAllCustomersAsync()
    {
        var result = await _customerService.GetAllCustomersAsync();

        return Ok(result.Value);
    }
}
