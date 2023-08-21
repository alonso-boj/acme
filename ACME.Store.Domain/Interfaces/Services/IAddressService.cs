using ACME.Store.Domain.Models.Requests;
using Ardalis.Result;
using System;
using System.Threading.Tasks;

namespace ACME.Store.Domain.Interfaces.Services;
public interface IAddressService
{
    Task<Result<Guid>> RegisterCustomerAddressAsync(RegisterCustomerAddressRequest request);
}