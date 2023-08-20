using ACME.Store.Domain.Entities;
using ACME.Store.Domain.Models.Requests;
using ACME.Store.Domain.Models.Responses;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ACME.Store.Domain.Interfaces.Services;

public interface ICustomerService
{
    Task<bool> RegisterCustomerAsync(RegisterCustomerRequest request);

    Task<IEnumerable<Customer>> GetAllCustomers();

    Task<GetCustomerDetailsResponse> GetCustomerDetails(Guid id);
}
