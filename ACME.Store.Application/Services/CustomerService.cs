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

    public CustomerService(IMapper mapper, ICustomerRepository customerRepository)
    {
        _mapper = mapper;
        _customerRepository = customerRepository;
    }

    public async Task<Result> RegisterCustomerAsync(RegisterCustomerRequest request)
    {
        var customer = _mapper.Map<Customer>(request);

        await _customerRepository.RegisterCustomerAsync(customer);

        return Result.Success();
    }

    public async Task<Result<IEnumerable<Customer>>> GetAllCustomers()
    {
        var customers = await _customerRepository.GetAllCustomers();

        if (!customers.Any())
        {
            return Result.Success(Enumerable.Empty<Customer>());
        }

        return Result.Success(customers);
    }

    public async Task<Result<GetCustomerDetailsResponse>> GetCustomerDetails(Guid id)
    {
        var customer = await _customerRepository.GetCustomerDetails(id);

        if (customer.Id == Guid.Empty)
        {
            return Result.NotFound();
        }

        var address = customer
            .Addresses
            .First(address => address.Main);

        var addressResponse = _mapper.Map<AddressResponse>(address);

        var response = new GetCustomerDetailsResponse(customer.Mail, addressResponse);

        return Result.Success(response);
    }
}
