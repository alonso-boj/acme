namespace ACME.Store.Domain.Models.Requests;

public record RegisterCustomerRequest(
    string Name,
    string Phone,
    string Mail);