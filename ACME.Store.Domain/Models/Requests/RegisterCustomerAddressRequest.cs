using System;

namespace ACME.Store.Domain.Models.Requests;
public record RegisterCustomerAddressRequest(
    bool Main,
    string Street,
    int Number,
    string Complement,
    string Neighborhood,
    string City,
    string State,
    int ZipCode,
    Guid CustomerId);
