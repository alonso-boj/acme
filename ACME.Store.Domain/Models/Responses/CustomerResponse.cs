namespace ACME.Store.Domain.Models.Responses;

public record CustomerResponse(
    string Name,
    string Phone,
    string Mail);
