using System.Collections.Generic;

namespace ACME.Store.Domain.Entities;

public sealed class Customer : BaseEntity
{
    public Customer()
    {

    }

    public Customer(string name, int phone, string mail)
    {
        Name = name;
        Phone = phone;
        Mail = mail;
    }

    public string Name { get; private set; } = string.Empty;

    public int Phone { get; private set; }

    public string Mail { get; private set; } = string.Empty;

    // Navigation property
    public ICollection<Address> Addresses { get; private set; } = new List<Address>();

    public bool AddAddress(Address address)
    {
        Addresses.Add(address);

        return true;
    }

    public bool RemoveAddress(Address address)
    {
        Addresses.Remove(address);

        return true;
    }
}
