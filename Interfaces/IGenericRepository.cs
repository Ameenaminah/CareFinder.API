using CareFinder.API.DTOs;

namespace CareFinder.API.Interfaces;

public interface IGenericRepository<T> where T : class
{
  Task<List<T>> GetAllAsync();
  Task<T> GetAsync(int? id);
  Task<T> AddAsync(T entity);
  Task DeleteAsync(int id);
  Task UpdateAsync(T entity);
  Task<bool> Exists(int id);
  Task<PagedResult<TResult>> GetAllAsync<TResult>(QueryParameters queryParameters);

}
