using ACME.Store.Domain.Models.Requests;
using ACME.Store.Domain.Models.Responses;
using Ardalis.Result;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ACME.Store.Domain.Interfaces.Services;

public interface ICustomerService
{
    /// <summary>
    /// Method to register a customer.
    /// </summary>
    /// <param name="request"></param>
    /// <returns>A result object that contains more information about the operation,
    /// including the customer's id if the operation was successful.</returns>
    Task<Result<Guid>> RegisterCustomerAsync(RegisterCustomerRequest request);

    /// <summary>
    /// Method to get all customers.
    /// </summary>
    /// <returns>A result object that contains more information about the operation,
    /// including an IEnumerable of type CustomerResponse if the operation was successful.</returns>
    Task<Result<IEnumerable<CustomerResponse>>> GetAllCustomersAsync();

    /// <summary>
    /// Method to retrieve customer details information.
    /// </summary>
    /// <param name="id">Customer id.</param>
    /// <returns>A result object that contains more information about the operation, 
    /// including an object of type GetCustomerDetailsResponse if the operation was successful.</returns>
    Task<Result<GetCustomerDetailsResponse>> GetCustomerDetailsAsync(Guid id);
}
