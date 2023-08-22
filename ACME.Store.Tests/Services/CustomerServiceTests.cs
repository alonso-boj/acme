using ACME.Store.Application.Configurations.AutoMapper;
using ACME.Store.Application.Services;
using ACME.Store.Domain.Entities;
using ACME.Store.Domain.Interfaces.Repositories;
using ACME.Store.Domain.Models.Requests;
using AutoMapper;
using Moq;
using System.Reflection;
using System.Threading.Tasks;
using Xunit;

namespace ACME.Store.Tests.Services;

public class CustomerServiceTests
{
    private static IMapper _mapper;

    public CustomerServiceTests()
    {
        if (_mapper is null)
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddMaps(Assembly.GetAssembly(typeof(CustomerProfile)));
            });

            mapperConfig.AssertConfigurationIsValid();

            IMapper mapper = mapperConfig.CreateMapper();

            _mapper = mapper;
        }
    }

    [Fact]
    public async Task RegisterCustomerAsync_Success_RepositoryRegisterCustomeryAsyncIsCalledOnce()
    {
        // Arrange
        var request = new RegisterCustomerRequest("Test", "31995854356", "test@test.com");

        var mock = new Mock<ICustomerRepository>();

        mock.Setup(repo => repo.RegisterCustomerAsync(It.IsAny<Customer>()))
            .Verifiable();

        var service = new CustomerService(mock.Object, _mapper);

        // Act
        await service.RegisterCustomerAsync(request);

        // Assert
        mock.Verify(repo => repo.RegisterCustomerAsync(It.IsAny<Customer>()), Times.Once());
    }
}
