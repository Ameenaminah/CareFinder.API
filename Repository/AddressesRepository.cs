using CareFinder.API.Data;
using CareFinder.API.Interfaces;

namespace CareFinder.API.Repository;

public class AddressesRepository : GenericRepository<Address>, IAddressesRepository
{
    public AddressesRepository(CareFinderDbContext context) : base(context)
    {
    }
}
