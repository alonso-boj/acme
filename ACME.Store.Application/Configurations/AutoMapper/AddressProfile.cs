using ACME.Store.Application.Extensions;
using ACME.Store.Domain.Entities;
using ACME.Store.Domain.Models.Requests;
using ACME.Store.Domain.Models.Responses;
using AutoMapper;

namespace ACME.Store.Application.Configurations.AutoMapper;

public class AddressProfile : Profile
{
    public AddressProfile()
    {
        CreateMap<AddressResponse, Address>()
        .IgnoreBaseEntityProperties()
        .ForMember(dest => dest.CustomerId, opt => opt.Ignore())
        .ReverseMap();

        CreateMap<RegisterAddressRequest, Address>()
        .IgnoreBaseEntityProperties()
        .ReverseMap();
    }
}
