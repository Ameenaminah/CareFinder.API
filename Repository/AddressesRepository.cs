using AutoMapper;
using CareFinder.API.Data;
using CareFinder.API.Interfaces;

namespace CareFinder.API.Repository;

public class AddressesRepository : GenericRepository<Address>, IAddressesRepository
{
    private readonly CareFinderDbContext _context;
    public AddressesRepository(CareFinderDbContext context, IMapper mapper) : base(context, mapper)
    {
        this._context = context;
    }
}
