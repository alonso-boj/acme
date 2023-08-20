using ACME.Store.Application.Extensions;
using ACME.Store.Domain.Entities;
using ACME.Store.Domain.Models.Requests;
using AutoMapper;

namespace ACME.Store.Application.Configuration.AutoMapper;

public class CustomerProfile : Profile
{
    public CustomerProfile()
    {
        CreateMap<RegisterCustomerRequest, Customer>()
        .IgnoreBaseEntityProperties()
        .ForMember(destination => destination.Addresses, opt => opt.Ignore())
        .ReverseMap();
    }
}
