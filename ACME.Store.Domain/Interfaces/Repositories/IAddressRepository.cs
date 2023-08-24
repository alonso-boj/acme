using ACME.Store.Domain.Entities;
using System.Threading.Tasks;

namespace ACME.Store.Domain.Interfaces.Repositories;

public interface IAddressRepository
{
    /// <summary>
    /// Method to register a customer address in the database.
    /// </summary>
    /// <param name="address">Address entitiy.</param>
    /// <returns></returns>
    Task RegisterAddressAsync(Address address);
}