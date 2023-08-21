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

    public async Task RegisterCustomerAsync(Customer customer)
    {
        _context.Customers.Add(customer);

        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
    {
        var customers = await _context
            .Customers
            .AsNoTracking()
            .ToArrayAsync();

        return customers;
    }

    public async Task<Customer?> GetCustomerDetailsAsync(Guid id)
    {
        var customer = await _context
            .Customers
            .Where(customer => customer.Id == id)
            .Include(customer => customer.Addresses)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        return customer;
    }
}
