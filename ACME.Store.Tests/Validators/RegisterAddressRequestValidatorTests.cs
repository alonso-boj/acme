using ACME.Store.Application.Validators;
using ACME.Store.Domain.Constants;
using ACME.Store.Domain.Models.Requests;
using System;
using Xunit;

namespace ACME.Store.Tests.Validators;

public class RegisterAddressRequestValidatorTests
{
    [Theory]
    [InlineData("", ValidationErrorMessages.STREET_NOT_EMPTY)]
    [InlineData(null, ValidationErrorMessages.STREET_NOT_EMPTY)]
    [InlineData("ab", ValidationErrorMessages.STREET_LENGTH)]
    [InlineData("Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text", ValidationErrorMessages.STREET_LENGTH)]
    public void RegisterAddressRequestValidator_InvalidStreet_ReturnsValidationErrors(
        string value, string expectedResult)
    {
        // Arrange
        var validator = new RegisterAddressRequestValidator();

        var request = new RegisterAddressRequest(
            Main: true,
            Street: value,
            Number: 1,
            Complement: "",
            Neighborhood: "Bairro B",
            City: "Cidade C",
            State: "Estado D",
            ZipCode: "31555555",
            CustomerId: Guid.NewGuid());

        // Act
        var result = validator.Validate(request);

        // Assert
        Assert.False(result.IsValid);

        Assert.True(result.Errors
            .Exists(validationFailure => validationFailure.ErrorMessage.Equals(expectedResult)));
    }

    [Fact]
    public void RegisterAddressRequestValidator_InvalidNumber_ReturnsValidationErrors()
    {
        // Arrange
        var validator = new RegisterAddressRequestValidator();

        var request = new RegisterAddressRequest(
            Main: true,
            Street: "Rua A",
            Number: 0,
            Complement: "",
            Neighborhood: "Bairro B",
            City: "Cidade C",
            State: "Estado D",
            ZipCode: "31555555",
            CustomerId: Guid.NewGuid());

        // Act
        var result = validator.Validate(request);

        // Assert
        Assert.False(result.IsValid);

        Assert.True(result.Errors
            .Exists(validationFailure => validationFailure.ErrorMessage.Equals(ValidationErrorMessages.NUMBER_NOT_EMPTY)));
    }

    [Theory]
    [InlineData(null, ValidationErrorMessages.COMPLEMENT_NOT_NULL)]
    [InlineData("ab", ValidationErrorMessages.COMPLEMENT_LENGTH)]
    [InlineData("Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text", ValidationErrorMessages.COMPLEMENT_LENGTH)]
    public void RegisterAddressRequestValidator_InvalidComplement_ReturnsValidationErrors(
        string value, string expectedResult)
    {
        // Arrange
        var validator = new RegisterAddressRequestValidator();

        var request = new RegisterAddressRequest(
            Main: true,
            Street: value,
            Number: 1,
            Complement: value,
            Neighborhood: "Bairro B",
            City: "Cidade C",
            State: "Estado D",
            ZipCode: "31555555",
            CustomerId: Guid.NewGuid());

        // Act
        var result = validator.Validate(request);

        // Assert
        Assert.False(result.IsValid);

        Assert.True(result.Errors
            .Exists(validationFailure => validationFailure.ErrorMessage.Equals(expectedResult)));
    }

    [Theory]
    [InlineData("", ValidationErrorMessages.NEIGHBORHOOD_NOT_EMPTY)]
    [InlineData(null, ValidationErrorMessages.NEIGHBORHOOD_NOT_EMPTY)]
    [InlineData("ab", ValidationErrorMessages.NEIGHBORHOOD_LENGTH)]
    [InlineData("Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text", ValidationErrorMessages.NEIGHBORHOOD_LENGTH)]
    public void RegisterAddressRequestValidator_InvalidNeighborhood_ReturnsValidationErrors(
    string value, string expectedResult)
    {
        // Arrange
        var validator = new RegisterAddressRequestValidator();

        var request = new RegisterAddressRequest(
            Main: true,
            Street: value,
            Number: 1,
            Complement: "",
            Neighborhood: value,
            City: value,
            State: "Estado D",
            ZipCode: "31555555",
            CustomerId: Guid.NewGuid());

        // Act
        var result = validator.Validate(request);

        // Assert
        Assert.False(result.IsValid);

        Assert.True(result.Errors
            .Exists(validationFailure => validationFailure.ErrorMessage.Equals(expectedResult)));
    }

    [Theory]
    [InlineData("", ValidationErrorMessages.CITY_NOT_EMPTY)]
    [InlineData(null, ValidationErrorMessages.CITY_NOT_EMPTY)]
    [InlineData("ab", ValidationErrorMessages.CITY_LENGTH)]
    [InlineData("Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text", ValidationErrorMessages.CITY_LENGTH)]
    public void RegisterAddressRequestValidator_InvalidCity_ReturnsValidationErrors(
        string value, string expectedResult)
    {
        // Arrange
        var validator = new RegisterAddressRequestValidator();

        var request = new RegisterAddressRequest(
            Main: true,
            Street: value,
            Number: 1,
            Complement: "",
            Neighborhood: "Bairro B",
            City: value,
            State: "Estado D",
            ZipCode: "31555555",
            CustomerId: Guid.NewGuid());

        // Act
        var result = validator.Validate(request);

        // Assert
        Assert.False(result.IsValid);

        Assert.True(result.Errors
            .Exists(validationFailure => validationFailure.ErrorMessage.Equals(expectedResult)));
    }

    [Theory]
    [InlineData("", ValidationErrorMessages.STATE_NOT_EMPTY)]
    [InlineData(null, ValidationErrorMessages.STATE_NOT_EMPTY)]
    [InlineData("ab", ValidationErrorMessages.STATE_LENGTH)]
    [InlineData("Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text", ValidationErrorMessages.STATE_LENGTH)]
    public void RegisterAddressRequestValidator_InvalidState_ReturnsValidationErrors(
        string value, string expectedResult)
    {
        // Arrange
        var validator = new RegisterAddressRequestValidator();

        var request = new RegisterAddressRequest(
            Main: true,
            Street: value,
            Number: 1,
            Complement: "",
            Neighborhood: "Bairro B",
            City: "Cidade C",
            State: value,
            ZipCode: "31555555",
            CustomerId: Guid.NewGuid());

        // Act
        var result = validator.Validate(request);

        // Assert
        Assert.False(result.IsValid);

        Assert.True(result.Errors
            .Exists(validationFailure => validationFailure.ErrorMessage.Equals(expectedResult)));
    }

    [Theory]
    [InlineData("", ValidationErrorMessages.ZIPCODE_NOT_EMPTY)]
    [InlineData(null, ValidationErrorMessages.ZIPCODE_NOT_EMPTY)]
    [InlineData("ab", ValidationErrorMessages.ZIPCODE_LENGTH)]
    [InlineData("Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text", ValidationErrorMessages.ZIPCODE_LENGTH)]
    public void RegisterAddressRequestValidator_InvalidZipCode_ReturnsValidationErrors(
      string value, string expectedResult)
    {
        // Arrange
        var validator = new RegisterAddressRequestValidator();

        var request = new RegisterAddressRequest(
            Main: true,
            Street: value,
            Number: 1,
            Complement: "",
            Neighborhood: "Bairro B",
            City: "Cidade C",
            State: "Estado D",
            ZipCode: value,
            CustomerId: Guid.NewGuid());

        // Act
        var result = validator.Validate(request);

        // Assert
        Assert.False(result.IsValid);

        Assert.True(result.Errors
            .Exists(validationFailure => validationFailure.ErrorMessage.Equals(expectedResult)));
    }
}
