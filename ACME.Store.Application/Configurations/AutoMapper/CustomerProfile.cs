using ACME.Store.Application.Extensions;
using ACME.Store.Domain.Entities;
using ACME.Store.Domain.Models.Requests;
using ACME.Store.Domain.Models.Responses;
using AutoMapper;

namespace ACME.Store.Application.Configurations.AutoMapper;

public class CustomerProfile : Profile
{
    public CustomerProfile()
    {
        CreateMap<RegisterCustomerRequest, Customer>()
        .IgnoreBaseEntityProperties()
        .ForMember(destination => destination.Addresses, opt => opt.Ignore())
        .ReverseMap();

        CreateMap<CustomerResponse, Customer>()
        .IgnoreBaseEntityProperties()
        .ForMember(destination => destination.Addresses, opt => opt.Ignore())
        .ReverseMap();
    }
}
