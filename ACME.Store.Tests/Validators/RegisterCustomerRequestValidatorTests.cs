using ACME.Store.Application.Validators;
using ACME.Store.Domain.Constants;
using ACME.Store.Domain.Models.Requests;
using Xunit;

namespace ACME.Store.Tests.Validators;

public class RegisterCustomerRequestValidatorTests
{
    [Theory]
    [InlineData("", ValidationErrorMessages.NAME_NOT_EMPTY)]
    [InlineData(null, ValidationErrorMessages.NAME_NOT_EMPTY)]
    [InlineData("ab", ValidationErrorMessages.NAME_LENGTH)]
    [InlineData("Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text", ValidationErrorMessages.NAME_LENGTH)]
    public void RegisterCustomerRequestValidator_InvalidName_ReturnsValidationErrors(
        string value, string expectedResult)
    {
        // Arrange
        var validator = new RegisterCustomerRequestValidator();

        var request = new RegisterCustomerRequest(value, "31999999999", "test@test.com");

        // Act
        var result = validator.Validate(request);

        // Assert
        Assert.False(result.IsValid);

        Assert.True(result.Errors
            .Exists(validationFailure => validationFailure.ErrorMessage.Equals(expectedResult)));
    }

    [Theory]
    [InlineData("", ValidationErrorMessages.PHONE_NOT_EMPTY)]
    [InlineData(null, ValidationErrorMessages.PHONE_NOT_EMPTY)]
    [InlineData("ab", ValidationErrorMessages.PHONE_LENGTH)]
    [InlineData("31999", ValidationErrorMessages.PHONE_LENGTH)]
    public void RegisterCustomerRequestValidator_InvalidPhone_ReturnsValidationErrors(
        string value, string expectedResult)
    {
        // Arrange
        var validator = new RegisterCustomerRequestValidator();

        var request = new RegisterCustomerRequest("Test", value, "test@test.com");

        // Act
        var result = validator.Validate(request);

        // Assert
        Assert.False(result.IsValid);

        Assert.True(result.Errors
            .Exists(validationFailure => validationFailure.ErrorMessage.Equals(expectedResult)));
    }

    [Theory]
    [InlineData("", ValidationErrorMessages.MAIL_NOT_EMPTY)]
    [InlineData(null, ValidationErrorMessages.MAIL_NOT_EMPTY)]
    [InlineData("test", ValidationErrorMessages.INVALID_MAIL)]
    public void RegisterCustomerRequestValidator_InvalidMail_ReturnsValidationErrors(
        string value, string expectedResult)
    {
        // Arrange
        var validator = new RegisterCustomerRequestValidator();

        var request = new RegisterCustomerRequest("Test", "31999999999", value);

        // Act
        var result = validator.Validate(request);

        // Assert
        Assert.False(result.IsValid);

        Assert.True(result.Errors
            .Exists(validationFailure => validationFailure.ErrorMessage.Equals(expectedResult)));
    }
}
