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
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace ACME.Store.Tests.Services;

public class CustomerServiceTests
{
    private readonly IMapper _mapper = MapperHelper
        .ConfigureAutoMapper(new CustomerProfile(), new AddressProfile());

    [Fact]
    public async Task RegisterCustomerAsync_Success_RepositoryRegisterCustomeryAsyncIsCalledOnce()
    {
        // Arrange
        var request = new RegisterCustomerRequest("Test", "31999999999", "test@test.com");

        var mock = new Mock<ICustomerRepository>();

        mock.Setup(repo => repo.RegisterCustomerAsync(It.IsAny<Customer>()))
            .Verifiable();

        var service = new CustomerService(mock.Object, _mapper);

        // Act
        var result = await service.RegisterCustomerAsync(request);

        // Assert
        mock.Verify(repo => repo.RegisterCustomerAsync(It.IsAny<Customer>()), Times.Once());
        Assert.True(result.IsSuccess);
    }

    [Fact]
    public async Task GetAllCustomersAsync_CustomersFound_ReturnsSuccessResultWithListOfCustomerResponse()
    {
        // Arrange
        var customers = new List<Customer>()
        {
            new Customer(),
            new Customer()
        }
        .AsEnumerable();

        var mock = new Mock<ICustomerRepository>();

        mock.Setup(repo => repo.GetAllCustomersAsync())
            .Returns(Task.FromResult(customers));

        var service = new CustomerService(mock.Object, _mapper);

        // Act
        var result = await service.GetAllCustomersAsync();

        // Assert
        Assert.True(result.IsSuccess);
        Assert.True(result.Value.Any());
    }

    [Fact]
    public async Task GetAllCustomersAsync_CustomersNotFoundFound_ReturnsSuccessResultWithEmptyListOfCustomerResponse()
    {
        // Arrange
        var customers = new List<Customer>().AsEnumerable();

        var mock = new Mock<ICustomerRepository>();

        mock.Setup(repo => repo.GetAllCustomersAsync())
            .Returns(Task.FromResult(customers));

        var service = new CustomerService(mock.Object, _mapper);

        // Act
        var result = await service.GetAllCustomersAsync();

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Empty(result.Value);
    }

    [Fact]
    public async Task GetCustomerDetailsAsync_CustomerFound_ReturnsSuccessResultWithGetCustomerDetailsResponse()
    {
        // Arrange
        var customer = new Customer("Test", "31999999999", "test@test.com");

        var address = new Address(
            main: true,
            street: "Rua A",
            number: 1,
            complement: "",
            neighborhood: "Bairro B",
            city: "Cidade C",
            state: "Estado D",
            zipCode: "31555555",
            customerId: customer.Id);

        customer.AddAddress(address);

        var mock = new Mock<ICustomerRepository>();

        mock
            .Setup(repo => repo
            .GetCustomerDetailsAsync(It.Is<Guid>(id => id.Equals(customer.Id))))
            .Returns(Task.FromResult<Customer?>(customer));

        var service = new CustomerService(mock.Object, _mapper);

        // Act
        var result = await service.GetCustomerDetailsAsync(customer.Id);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.True(result.Value.Mail.Equals(customer.Mail));
        Assert.True(result.Value.Address.Street.Equals(address.Street));
    }

    [Fact]
    public async Task GetCustomerDetailsAsync_CustomerNotFound_ReturnsNotFoundResultWithErrorMessage()
    {
        // Arrange
        var id = Guid.NewGuid();

        var mock = new Mock<ICustomerRepository>();

        mock
            .Setup(repo => repo
            .GetCustomerDetailsAsync(It.IsAny<Guid>()))
            .Returns(Task.FromResult<Customer?>(null));

        var service = new CustomerService(mock.Object, _mapper);

        // Act
        var result = await service.GetCustomerDetailsAsync(id);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.True(result.Status.Equals(ResultStatus.NotFound));
        Assert.True(result.Errors.First().Equals($"Customer with {id} was not found"));
    }
}
