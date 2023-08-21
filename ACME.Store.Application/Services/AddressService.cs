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
    private readonly IMapper _mapper;

    public AddressService(IAddressRepository addressRepository, IMapper mapper)
    {
        _addressRepository = addressRepository;
        _mapper = mapper;
    }

    public async Task<Result<Guid>> RegisterCustomerAddressAsync(RegisterCustomerAddressRequest request)
    {
        var address = _mapper.Map<Address>(request);

        await _addressRepository.RegisterCustomerAddressAsync(address);

        return Result.Success(address.Id);
    }
}
