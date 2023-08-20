using ACME.Store.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ACME.Store.Domain.Interfaces.Repositories;

public interface ICustomerRepository
{
    Task<bool> RegisterCustomerAsync(Customer customer);

    Task<IEnumerable<Customer>> GetAllCustomers();

    Task<Customer> GetCustomerDetails(Guid id);
}
