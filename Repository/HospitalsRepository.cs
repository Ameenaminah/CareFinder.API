﻿using AutoMapper;
using CareFinder.API.Data;
using CareFinder.API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CareFinder.API.Repository;

public class HospitalsRepository : GenericRepository<Hospital>, IHospitalsRepository
{
  private readonly CareFinderDbContext _context;
  public HospitalsRepository(CareFinderDbContext context, IMapper mapper) : base(context, mapper)
  {
    this._context = context;
  }

  public async Task<Hospital> GetDetails(int id)
  {
    return await _context.Hospitals.Include(q => q.Addresses).FirstOrDefaultAsync(q => q.Id == id);
  }
  public async Task<List<Hospital>> GetAllHospitalAsync()
  {
    return await _context.Hospitals.Include(h => h.Addresses).ToListAsync();
  }
}
