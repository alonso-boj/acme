using ACME.Store.Domain.Entities;
using ACME.Store.Infrastructure.Configurations.Mappings;
using Microsoft.EntityFrameworkCore;
using System;

namespace ACME.Store.Infrastructure.Configurations;

public class StoreContext : DbContext
{
    public DbSet<Customer> Customers { get; set; }

    public DbSet<Address> Addresses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=database,1433;Database=acme-store;User ID=sa;Password=1q2w3e4r@#$;TrustServerCertificate=True")
            .EnableSensitiveDataLogging(true)
            .EnableDetailedErrors(true)
            .LogTo(Console.WriteLine);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CustomerMap());
        modelBuilder.ApplyConfiguration(new AddressMap());
    }
}
