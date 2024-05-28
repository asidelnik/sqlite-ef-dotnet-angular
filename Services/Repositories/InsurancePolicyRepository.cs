using Microsoft.EntityFrameworkCore;
using sqlink.Data;
using sqlink.Models;
using sqlink.Services.IRepositories;

namespace sqlink.Services.Repositories;

public class InsurancePolicyRepository : IInsurancePolicyRepository
{
  private readonly InsuranceDbContext _context;
  public InsurancePolicyRepository(InsuranceDbContext context)
  {
    _context = context;
  }

  public async Task<IEnumerable<InsurancePolicy>> GetAsync() => await _context.InsurancePolicies.ToListAsync();

  public async Task<InsurancePolicy> GetById(int id)
  {
    var insurancePolicy = await _context.InsurancePolicies.FindAsync(id);
    if (insurancePolicy != null)
    {
      return insurancePolicy;
    }
    else
    {
      throw new Exception("Insurance plicy not found.");
    }
  }

  public async Task<bool> Add(InsurancePolicy entity)
  {
    await _context.InsurancePolicies.AddAsync(entity);
    return await _context.SaveChangesAsync() > 0;
  }
  public async Task<bool> Update(InsurancePolicy entity)
  {
    _context.InsurancePolicies.Update(entity);
    return await _context.SaveChangesAsync() > 0;
  }

  public async Task<bool> Delete(int id)
  {
    var entity = await _context.InsurancePolicies.FindAsync(id);
    _context.InsurancePolicies.Remove(entity);
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