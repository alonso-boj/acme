namespace ACME.Store.Domain.Models.Responses;

public record GetCustomerDetailsResponse(
    string Mail,
    AddressResponse Address);
