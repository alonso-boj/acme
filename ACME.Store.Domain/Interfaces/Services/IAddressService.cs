using ACME.Store.Domain.Dtos.Requests;
using System.Threading.Tasks;

namespace ACME.Store.Domain.Interfaces.Services;

public interface IAddressService
{
    Task<bool> RegisterCustomerAddressAsync(RegisterCustomerAddressRequestDto requestDto);
}
