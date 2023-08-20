using System;

namespace ACME.Store.Domain.Dtos.Requests;
public record RegisterCustomerAddressRequestDto(
    bool Main,
    string Street,
    int Number,
    string Complement,
    string Neighborhood,
    string City,
    string State,
    int ZipCode,
    Guid CustomerId);
