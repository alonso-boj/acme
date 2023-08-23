using ACME.Store.Application.Validators;
using ACME.Store.Domain.Models.Requests;
using Xunit;

namespace ACME.Store.Tests.Validators;

public class RegisterCustomerRequestValidatorTests
{
    [Fact]
    public void RegisterCustomerRequestValidator_InvalidName_ReturnsValidationErrors()
    {
        // Arrange
        var validator = new RegisterCustomerRequestValidator();

        var request = new RegisterCustomerRequest("", "31999999999", "test@test.com");

        // Act
        var result = validator.Validate(request);

        // Assert
        Assert.False(result.IsValid);

        Assert.True(result.Errors
            .Exists(validationFailure => validationFailure.ErrorMessage.Equals("Name cannot be empty or null")));

        Assert.True(result.Errors
            .Exists(validationFailure => validationFailure.ErrorMessage.Equals("Name must be between 3 and 128 characters")));
    }

    [Fact]
    public void RegisterCustomerRequestValidator_InvalidPhone_ReturnsValidationErrors()
    {
        // Arrange
        var validator = new RegisterCustomerRequestValidator();

        var request = new RegisterCustomerRequest("Test", "", "test@test.com");

        // Act
        var result = validator.Validate(request);

        // Assert
        Assert.False(result.IsValid);

        Assert.True(result.Errors
            .Exists(validationFailure => validationFailure.ErrorMessage.Equals("Phone cannot be empty or null")));

        Assert.True(result.Errors
            .Exists(validationFailure => validationFailure.ErrorMessage.Equals("Phone must be exactly 11 characters")));
    }

    [Fact]
    public void RegisterCustomerRequestValidator_InvalidMail_ReturnsValidationErrors()
    {
        // Arrange
        var validator = new RegisterCustomerRequestValidator();

        var request = new RegisterCustomerRequest("Test", "31999999999", "");

        // Act
        var result = validator.Validate(request);

        // Assert
        Assert.False(result.IsValid);

        Assert.True(result.Errors
            .Exists(validationFailure => validationFailure.ErrorMessage.Equals("Mail cannot be empty or null")));

        Assert.True(result.Errors
            .Exists(validationFailure => validationFailure.ErrorMessage.Equals("Mail must be a valid e-mail address")));
    }
}
