using System;

namespace ACME.Store.Domain.Models.Requests;
public record RegisterAddressRequest(
    bool Main,
    string Street,
    int Number,
    string Complement,
    string Neighborhood,
    string City,
    string State,
    string ZipCode,
    Guid CustomerId);
