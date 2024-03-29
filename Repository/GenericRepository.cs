﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using CareFinder.API.Data;
using CareFinder.API.DTOs;
using CareFinder.API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CareFinder.API;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
  private readonly CareFinderDbContext _context;
  private readonly IMapper _mapper;
  public GenericRepository(CareFinderDbContext context, IMapper mapper)
  {
    this._context = context;
    this._mapper = mapper;
  }

  public async Task<T> AddAsync(T entity)
  {
    await _context.AddAsync(entity);
    await _context.SaveChangesAsync();
    return entity;
  }

  public async Task DeleteAsync(int id)
  {
    var entity = await GetAsync(id);
    _context.Set<T>().Remove(entity);
    await _context.SaveChangesAsync();
  }

  public async Task<bool> Exists(int id)
  {
    var entity = await GetAsync(id);
    return entity != null;
  }

  public async Task<List<T>> GetAllAsync()
  {
    return await _context.Set<T>().ToListAsync();

  }

  public async Task<T> GetAsync(int? id)
  {
    if (id is null)
    {
      return null;
    }
    return await _context.Set<T>().FindAsync(id);
  }

  public async Task UpdateAsync(T entity)
  {
    _context.Update(entity);
    await _context.SaveChangesAsync();
  }

  public async Task<PagedResult<TResult>> GetAllAsync<TResult>(QueryParameters queryParameters)
  {
    var totalSize = await _context.Set<T>().CountAsync();
    var items = await _context.Set<T>()
        .Skip(queryParameters.StartIndex)
        .Take(queryParameters.PageSize)
        .ProjectTo<TResult>(_mapper.ConfigurationProvider)
        .ToListAsync();

    return new PagedResult<TResult>
    {
      Items = items,
      PageNumber = queryParameters.PageNumber,
      RecordNumber = queryParameters.PageSize,
      TotalCount = totalSize

    };
  }

  public async Task<bool> ExistsByNameAsync(string name)
  {
    return await _context.Set<Hospital>().AnyAsync(h => h.Name == name);
  }
}
