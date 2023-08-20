namespace ACME.Store.Domain.Models.Responses;

public record AddressResponse(
    bool Main,
    string Street,
    int Number,
    string Complement,
    string Neighborhood,
    string City,
    string State,
    int ZipCode);
