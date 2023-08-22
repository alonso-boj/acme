using ACME.Store.Domain.Interfaces.Services;
using ACME.Store.Domain.Models.Requests;
using Ardalis.Result;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace ACME.Store.Presentation.Controllers;

[ApiController]
[Route("api")]
[Produces("application/json")]
public class AddressController : StandardController
{
    private readonly IAddressService _addressService;
    private readonly IValidator<RegisterAddressRequest> _validator;

    public AddressController(
        IAddressService addressService,
        IValidator<RegisterAddressRequest> validator)
    {
        _addressService = addressService;
        _validator = validator;
    }

    [HttpPost("address/registration")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status422UnprocessableEntity)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> RegisterAddressAsync([FromBody] RegisterAddressRequest request)
    {
        var validationResult = await _validator.ValidateAsync(request);

        if (!validationResult.IsValid)
        {
            var validationProblemDetails = GetValidationProblemDetails(validationResult);

            return UnprocessableEntity(validationProblemDetails);
        }

        var result = await _addressService.RegisterAddressAsync(request);

        if (result.Status == ResultStatus.NotFound)
        {
            return NotFound(new { Error = result.Errors.First() });
        }

        return new ObjectResult(new { Id = result.Value })
        {
            StatusCode = StatusCodes.Status201Created
        };
    }
}
