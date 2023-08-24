using ACME.Store.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ACME.Store.Domain.Interfaces.Repositories;

public interface ICustomerRepository
{
    /// <summary>
    /// Method to register a customer in the database.
    /// </summary>
    /// <param name="customer">Customer entity.</param>
    /// <returns></returns>
    Task RegisterCustomerAsync(Customer customer);

    /// <summary>
    /// Method to get all customers registered from the database.
    /// </summary>
    /// <returns>An IEnumerable of customers.</returns>
    Task<IEnumerable<Customer>> GetAllCustomersAsync();

    /// <summary>
    /// Method to retrieve customer details information from the database.
    /// </summary>
    /// <param name="id">Customer id.</param>
    /// <returns>Customer entity or null.</returns>
    Task<Customer?> GetCustomerDetailsAsync(Guid id);
}
