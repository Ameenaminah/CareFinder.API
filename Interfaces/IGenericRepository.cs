using CareFinder.API.DTOs;

namespace CareFinder.API.Interfaces;

public interface IGenericRepository<T> where T : class
{
  Task<List<T>> GetAllAsync();
  Task<T> GetAsync(string id);
  Task<T> AddAsync(T entity);
  Task DeleteAsync(string id);
  Task UpdateAsync(T entity);
  Task<bool> Exists(String id);
  Task<bool> ExistsByNameAsync(string name);
  Task<PagedResult<TResult>> GetAllAsync<TResult>(QueryParameters queryParameters);

}
