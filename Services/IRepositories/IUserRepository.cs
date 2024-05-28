using sqlink.Models;
namespace sqlink.Services.IRepositories;

public interface IUserRepository : IDisposable
{
  Task<IEnumerable<User>> GetAsync();
  Task<User> GetByIdAsync(int id);
  public Task<bool> AddAsync(User entity);
  public Task<bool> UpdateAsync(User entity);
  public Task<bool> DeleteAsync(int id);
  void Save();
}