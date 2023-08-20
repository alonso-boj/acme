using ACME.Store.Domain.Dtos.Requests;
using ACME.Store.Domain.Entities;
using ACME.Store.Domain.Interfaces.Services;
using AutoMapper;
using System.Threading.Tasks;

namespace ACME.Store.Application;

public class CustomerService : ICustomerService
{
    //private readonly ICustomerRepository _customerRepository;
    //private readonly IAddressService _addressService;

    private readonly IMapper _mapper;

    public CustomerService(IMapper mapper/*ICustomerRepository customerRepository, IAddressService addressService*/)
    {
        _mapper = mapper;
        //_customerRepository = customerRepository;
        //_addressService = addressService;
    }

    public Task<bool> RegisterCustomerAsync(RegisterCustomerRequestDto requestDto)
    {
        var customer = _mapper.Map<Customer>(requestDto);

        return Task.FromResult(true);
    }
}
