using ACME.Store.Application.Extensions;
using ACME.Store.Domain.Dtos.Requests;
using ACME.Store.Domain.Entities;
using AutoMapper;

namespace ACME.Store.Application.Configuration.AutoMapper;

public class CustomerProfile : Profile
{
    public CustomerProfile()
    {
        CreateMap<RegisterCustomerRequestDto, Customer>()
        .IgnoreBaseEntityProperties()
        .ForMember(destination => destination.Addresses, opt => opt.Ignore());
    }
}
