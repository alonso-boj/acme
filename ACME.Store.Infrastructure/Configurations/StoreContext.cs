using ACME.Store.Domain.Entities;
using ACME.Store.Infrastructure.Configurations.Mappings;
using Microsoft.EntityFrameworkCore;
using System;

namespace ACME.Store.Infrastructure.Configurations;

public class StoreContext : DbContext
{
    public StoreContext(DbContextOptions<StoreContext> options) : base(options)
    {
        
    }

    public DbSet<Customer> Customers { get; set; }

    public DbSet<Address> Addresses { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CustomerMap());
        modelBuilder.ApplyConfiguration(new AddressMap());
    }
}
