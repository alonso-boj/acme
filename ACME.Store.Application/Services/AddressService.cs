using ACME.Store.Domain.Entities;
using ACME.Store.Domain.Interfaces.Repositories;
using ACME.Store.Domain.Interfaces.Services;
using ACME.Store.Domain.Models.Requests;
using Ardalis.Result;
using AutoMapper;
using System;
using System.Threading.Tasks;

namespace ACME.Store.Application.Services;

public class AddressService : IAddressService
{
    private readonly IAddressRepository _addressRepository;
    private readonly ICustomerRepository _customerRepository;
    private readonly IMapper _mapper;

    public AddressService(
        IAddressRepository addressRepository,
        ICustomerRepository customerRepository,
        IMapper mapper)
    {
        _addressRepository = addressRepository;
        _customerRepository = customerRepository;
        _mapper = mapper;
    }

    public async Task<Result<Guid>> RegisterAddressAsync(RegisterAddressRequest request)
    {
        var address = _mapper.Map<Address>(request);

        var customer = await _customerRepository.GetCustomerDetailsAsync(address.CustomerId);

        if (customer is null)
        {
            return Result.NotFound($"Customer with id {address.CustomerId} was not found");
        }

        await _addressRepository.RegisterAddressAsync(address);

        return Result.Success(address.Id);
    }
}
