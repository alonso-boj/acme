using ACME.Store.Domain.Entities;
using ACME.Store.Domain.Interfaces.Repositories;
using ACME.Store.Infrastructure.Configurations;
using System.Threading.Tasks;

namespace ACME.Store.Infrastructure.Repositories;

public class AddressRepository : IAddressRepository
{
    private readonly StoreContext _context;

    public AddressRepository(StoreContext context)
    {
        _context = context;
    }

    public async Task RegisterCustomerAddressAsync(Address address)
    {
        _context.Addresses.Add(address);

        await _context.SaveChangesAsync();
    }
}
