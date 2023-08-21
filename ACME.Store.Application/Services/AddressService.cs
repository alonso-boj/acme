using ACME.Store.Domain.Entities;
using ACME.Store.Domain.Interfaces.Repositories;
using ACME.Store.Domain.Interfaces.Services;
using ACME.Store.Domain.Models.Requests;
using AutoMapper;
using System.Threading.Tasks;

namespace ACME.Store.Application.Services;

public class AddressService : IAddressService
{
    private readonly IMapper _mapper;
    private readonly IAddressRepository _addressRepository;

    public AddressService(IMapper mapper, IAddressRepository addressRepository)
    {
        _mapper = mapper;
        _addressRepository = addressRepository;
    }

    public async Task<bool> RegisterCustomerAddressAsync(RegisterCustomerAddressRequest request)
    {
        var address = _mapper.Map<Address>(request);

        await _addressRepository.RegisterCustomerAddressAsync(address);

        return true;
    }
}
