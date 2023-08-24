using ACME.Store.Domain.Models.Requests;
using Ardalis.Result;
using System;
using System.Threading.Tasks;

namespace ACME.Store.Domain.Interfaces.Services;
public interface IAddressService
{
    /// <summary>
    /// Method to register a customer address.
    /// </summary>
    /// <param name="request">Data transfer object for customer address registration.</param>
    /// <returns>A result object that contains more information about the operation, 
    /// including the customer's address id if the operation was successful.</returns>
    Task<Result<Guid>> RegisterAddressAsync(RegisterAddressRequest request);
}