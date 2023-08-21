using ACME.Store.Domain.Entities;
using System.Threading.Tasks;

namespace ACME.Store.Domain.Interfaces.Repositories;

public interface IAddressRepository
{
    Task<bool> RegisterCustomerAddressAsync(Address address);
}