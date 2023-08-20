using ACME.Store.Domain.Dtos.Requests;
using System.Threading.Tasks;

namespace ACME.Store.Domain.Interfaces.Services;

public interface ICustomerService
{
    Task<bool> RegisterCustomerAsync(RegisterCustomerRequestDto requestDto);
}
