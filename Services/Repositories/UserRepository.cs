using Microsoft.EntityFrameworkCore;
using sqlink.Data;
using sqlink.Models;
using sqlink.Services.IRepositories;

namespace sqlink.Services.Repositories;

public class UserRepository : IUserRepository
{
  private readonly InsuranceDbContext _context;
  public UserRepository(InsuranceDbContext context)
  {
    _context = context;
  }

  public async Task<IEnumerable<User>> GetAsync() => await _context.Users.ToListAsync();

  public async Task<User> GetByIdAsync(int id)
  {
    var user = await _context.Users.FindAsync(id);
    if (user != null)
    {
      return user;
    }
    else
    {
      throw new Exception("User not found.");
    }
  }

  public async Task<bool> AddAsync(User entity)
  {
    await _context.Users.AddAsync(entity);
    return await _context.SaveChangesAsync() > 0;
  }
  public async Task<bool> UpdateAsync(User entity)
  {
    _context.Users.Update(entity);
    return await _context.SaveChangesAsync() > 0;
  }

  public async Task<bool> DeleteAsync(int id)
  {
    var entity = await _context.Users.FindAsync(id);
    _context.Users.Remove(entity);
    return await _context.SaveChangesAsync() > 0;
  }

  public void Save()
  {
    _context.SaveChanges();
  }


  public void Dispose()
  {
    _context.Dispose();
  }
}