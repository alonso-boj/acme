using System;

namespace ACME.Store.Domain.Entities;

public sealed class Address : BaseEntity
{
    public Address()
    {

    }

    public Address(bool main, string street, int number,
        string complement, string neighborhood, string city,
        string state, string zipCode, Guid customerId)
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
    }

    public bool Main { get; private set; }

    public string Street { get; private set; } = string.Empty;

    public int Number { get; private set; }

    public string Complement { get; private set; } = string.Empty;

    public string Neighborhood { get; private set; } = string.Empty;

    public string City { get; private set; } = string.Empty;

    public string State { get; private set; } = string.Empty;

    public string ZipCode { get; private set; } = string.Empty;

    // Foreign key property
    public Guid CustomerId { get; private set; }
}
