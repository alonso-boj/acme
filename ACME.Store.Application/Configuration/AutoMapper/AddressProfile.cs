using ACME.Store.Application.Extensions;
using ACME.Store.Domain.Entities;
using ACME.Store.Domain.Models.Requests;
using ACME.Store.Domain.Models.Responses;
using AutoMapper;

namespace ACME.Store.Application.Configuration.AutoMapper;

public class AddressProfile : Profile
{
    public AddressProfile()
    {
        CreateMap<AddressResponse, Address>()
        .IgnoreBaseEntityProperties()
        .ReverseMap();

        CreateMap<RegisterCustomerAddressRequest, Address>()
        .IgnoreBaseEntityProperties()
        .ReverseMap();
    }
}
