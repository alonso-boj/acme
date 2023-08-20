using ACME.Store.Domain.Models.Requests;
using System.Threading.Tasks;

namespace ACME.Store.Domain.Interfaces.Services;

public interface IAddressService
{
    Task<bool> RegisterCustomerAddressAsync(RegisterCustomerAddressRequest requestDto);
}
