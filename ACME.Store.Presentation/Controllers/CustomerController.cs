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
    private readonly IValidator<RegisterCustomerRequest> _registerCustomerRequestValidator;

    private readonly ICustomerService _customerService;
    private readonly IAddressService _addressService;

    public CustomerController(
        IValidator<RegisterCustomerRequest> registerCustomerRequestValidator,

        ICustomerService customerService,
        IAddressService addressService)
    {
        _registerCustomerRequestValidator = registerCustomerRequestValidator;

        _customerService = customerService;
        _addressService = addressService;
    }

    [HttpPost("customer/registration")]
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

        await _customerService.RegisterCustomerAsync(request);

        return Ok();
    }

    [HttpPost("customer/address/registration")]
    [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status422UnprocessableEntity)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> RegisterCustomerAddressAsync([FromBody] RegisterCustomerAddressRequest request)
    {
        await _addressService.RegisterCustomerAddressAsync(request);

        return Ok();
    }

    [HttpGet("customer/details")]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetCustomerDetailsAsync([FromQuery] Guid id)
    {
        var customerDetails = await _customerService.GetCustomerDetails(id);

        return Ok(customerDetails);
    }

    [HttpGet("customers")]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetAllCustomersAsync()
    {
        var customers = await _customerService.GetAllCustomers();

        return Ok(customers);
    }
}
