using System;

namespace ACME.Store.Domain.Entities;

public sealed class Address : BaseEntity
{
    public Address(bool main, string street, int number,
        string complement, string neighborhood, string city,
        string state, int zipCode, Guid customerId, Customer customer)
    {
        Main = main;
        Street = street;
        Number = number;
        Complement = complement;
        Neighborhood = neighborhood;
        City = city;
        State = state;
        ZipCode = zipCode;
        CustomerId = customerId;
        Customer = customer;
    }

    public bool Main { get; private set; }

    public string Street { get; private set; }

    public int Number { get; private set; }

    public string Complement { get; private set; }

    public string Neighborhood { get; private set; }

    public string City { get; private set; }

    public string State { get; private set; }

    public int ZipCode { get; private set; }

    // Foreign key property
    public Guid CustomerId { get; private set; }

    // Navigation property
    public Customer Customer { get; private set; }
}
