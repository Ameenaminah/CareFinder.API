using CareFinder.API.Data;

namespace CareFinder.API.Interfaces;

public interface IHospitalsRepository: IGenericRepository<Hospital>
{
  Task<Hospital> GetDetails(int id);
}
