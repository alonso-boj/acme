using ACME.Store.Application.Configurations.AutoMapper;
using ACME.Store.Application.Services;
using ACME.Store.Domain.Entities;
using ACME.Store.Domain.Interfaces.Repositories;
using ACME.Store.Domain.Models.Requests;
using ACME.Store.Tests.Helpers;
using Ardalis.Result;
using AutoMapper;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace ACME.Store.Tests.Services;

public class AddressServiceTests
{
    private readonly IMapper _mapper = MapperHelper
        .ConfigureAutoMapper(new CustomerProfile(), new AddressProfile());

    [Fact]
    public async Task RegisterAddressAsync_CustomerFound_ReturnsSuccessResultWithAddressId()
    {
        // Arrange
        var customer = new Customer("Test", "31999999999", "test@test.com");

        var request = new RegisterAddressRequest(
            Main: true,
            Street: "Rua A",
            Number: 1,
            Complement: "",
            Neighborhood: "Bairro B",
            City: "Cidade C",
            State: "Estado D",
            ZipCode: "31555555",
            CustomerId: customer.Id);

        var customerRepositoryMock = new Mock<ICustomerRepository>();

        customerRepositoryMock
        .Setup(repo => repo
            .GetCustomerDetailsAsync(It.Is<Guid>(id => id.Equals(customer.Id))))
            .Returns(Task.FromResult<Customer?>(customer));

        var addressRepositoryMock = new Mock<IAddressRepository>();

        addressRepositoryMock.Setup(repo => repo.RegisterAddressAsync(It.IsAny<Address>()))
        .Verifiable();

        var service = new AddressService(
            addressRepositoryMock.Object,
            customerRepositoryMock.Object,
            _mapper);

        // Act
        var result = await service.RegisterAddressAsync(request);

        // Assert
        addressRepositoryMock.Verify(repo => repo.RegisterAddressAsync(
            It.IsAny<Address>()),
            Times.Once());

        Assert.True(result.IsSuccess);
    }

    [Fact]
    public async Task RegisterAddressAsync_CustomerNotFound_ReturnsNotFoundResultWithErrorMessage()
    {
        // Arrange
        var customerId = Guid.NewGuid();

        var request = new RegisterAddressRequest(
            Main: true,
            Street: "Rua A",
            Number: 1,
            Complement: "",
            Neighborhood: "Bairro B",
            City: "Cidade C",
            State: "Estado D",
            ZipCode: "31555555",
            CustomerId: customerId);

        var customerRepositoryMock = new Mock<ICustomerRepository>();

        customerRepositoryMock
            .Setup(repo => repo
            .GetCustomerDetailsAsync(It.Is<Guid>(id => id.Equals(customerId))))
            .Returns(Task.FromResult<Customer?>(null));

        var addressRepositoryMock = new Mock<IAddressRepository>();

        addressRepositoryMock
            .Setup(repo => repo
            .RegisterAddressAsync(It.Is<Address>(address => address.CustomerId == customerId)))
            .Verifiable();

        var service = new AddressService(
            addressRepositoryMock.Object,
            customerRepositoryMock.Object,
            _mapper);

        // Act
        var result = await service.RegisterAddressAsync(request);

        // Assert
        addressRepositoryMock.Verify(repo => repo.RegisterAddressAsync(
            It.IsAny<Address>()),
            Times.Never());

        Assert.False(result.IsSuccess);
        Assert.True(result.Status.Equals(ResultStatus.NotFound));
    }
}
