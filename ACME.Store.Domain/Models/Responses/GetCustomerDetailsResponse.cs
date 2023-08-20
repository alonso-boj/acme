namespace ACME.Store.Domain.Models.Responses;

public record GetCustomerDetailsResponse(string Email, AddressResponse address);
