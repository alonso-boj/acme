using ACME.Store.Domain.Entities;
using ACME.Store.Domain.Interfaces.Repositories;
using ACME.Store.Domain.Interfaces.Services;
using ACME.Store.Domain.Models.Requests;
using ACME.Store.Domain.Models.Responses;
using Ardalis.Result;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ACME.Store.Application.Services;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _customerRepository;

    private readonly IMapper _mapper;

    public CustomerService(ICustomerRepository customerRepository, IMapper mapper)
    {
        _customerRepository = customerRepository;
        _mapper = mapper;
    }

    public async Task<Result<Guid>> RegisterCustomerAsync(RegisterCustomerRequest request)
    {
        var customer = _mapper.Map<Customer>(request);

        await _customerRepository.RegisterCustomerAsync(customer);

        return Result.Success(customer.Id);
    }

    public async Task<Result<IEnumerable<CustomerResponse>>> GetAllCustomers()
    {
        var customers = await _customerRepository.GetAllCustomersAsync();

        if (!customers.Any())
        {
            return Result.Success(Enumerable.Empty<CustomerResponse>());
        }

        var response = _mapper.Map<IEnumerable<CustomerResponse>>(customers);

        return Result.Success(response);
    }

    public async Task<Result<GetCustomerDetailsResponse>> GetCustomerDetails(Guid id)
    {
        var customer = await _customerRepository.GetCustomerDetailsAsync(id);

        if (customer is null)
        {
            return Result.NotFound();
        }

        var mainAddress = customer
            .Addresses
            .FirstOrDefault(address => address.Main);

        var mainAddressResponse = _mapper.Map<AddressResponse>(mainAddress);

        var response = new GetCustomerDetailsResponse(customer.Mail, mainAddressResponse);

        return Result.Success(response);
    }
}
