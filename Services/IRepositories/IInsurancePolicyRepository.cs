using sqlink.Models;
namespace sqlink.Services.IRepositories;

public interface IInsurancePolicyRepository : IDisposable
{
  Task<IEnumerable<InsurancePolicy>> GetAsync();
  Task<InsurancePolicy> GetByIdAsync(int id);
  public Task<bool> AddAsync(InsurancePolicy entity);
  public Task<bool> UpdateAsync(InsurancePolicy entity);
  public Task<bool> DeleteAsync(int id);
  void Save();
}