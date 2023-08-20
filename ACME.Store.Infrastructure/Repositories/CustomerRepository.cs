using ACME.Store.Domain.Entities;
using ACME.Store.Domain.Interfaces.Repositories;
using ACME.Store.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ACME.Store.Infrastructure.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly StoreContext _context;

    public CustomerRepository(StoreContext context)
    {
        _context = context;
    }

    public async Task<bool> RegisterCustomerAsync(Customer customer)
    {
        _context.Customers.Add(customer);

        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<IEnumerable<Customer>> GetAllCustomers()
    {
        var customers = await _context
            .Customers
            .IgnoreAutoIncludes()
            .AsNoTracking()
            .ToArrayAsync();

        return customers;
    }

    public async Task<Customer> GetCustomerDetails(Guid id)
    {
        var customer = await _context
            .Customers
            .Where(customer => customer.Id == id)
            .Include(customer => customer.Addresses)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (customer is null)
        {
            return new Customer()
            {
                Id = Guid.Empty
            };
        }

        return customer;
    }
}
