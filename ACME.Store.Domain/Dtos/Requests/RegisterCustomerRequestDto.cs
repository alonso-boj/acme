namespace ACME.Store.Domain.Dtos.Requests;

public record RegisterCustomerRequestDto(
    string Name,
    int Phone,
    string Mail);