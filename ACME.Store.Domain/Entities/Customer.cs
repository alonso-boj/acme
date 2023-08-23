using System.Collections.Generic;

namespace ACME.Store.Domain.Entities;

public sealed class Customer : BaseEntity
{
    public Customer()
    {

    }

    public Customer(string name, string phone, string mail)
    {
        Name = name;
        Phone = phone;
        Mail = mail;
    }

    public string Name { get; private set; } = string.Empty;

    public string Phone { get; private set; } = string.Empty;

    public string Mail { get; private set; } = string.Empty;

    // Navigation property
    public ICollection<Address> Addresses { get; private set; } = new List<Address>();

    public void AddAddress(Address address)
    {
        Addresses.Add(address);
    }
}
