using ACME.Store.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ACME.Store.Domain.Interfaces.Repositories;

public interface ICustomerRepository
{
    Task RegisterCustomerAsync(Customer customer);

    Task<IEnumerable<Customer>> GetAllCustomersAsync();

    Task<Customer?> GetCustomerDetailsAsync(Guid id);
}
