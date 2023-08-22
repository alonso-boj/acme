using ACME.Store.Domain.Models.Requests;
using ACME.Store.Domain.Models.Responses;
using Ardalis.Result;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ACME.Store.Domain.Interfaces.Services;

public interface ICustomerService
{
    Task<Result<Guid>> RegisterCustomerAsync(RegisterCustomerRequest request);

    Task<Result<IEnumerable<CustomerResponse>>> GetAllCustomersAsync();

    Task<Result<GetCustomerDetailsResponse>> GetCustomerDetailsAsync(Guid id);
}
