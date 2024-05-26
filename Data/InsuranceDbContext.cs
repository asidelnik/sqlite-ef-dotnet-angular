using Microsoft.EntityFrameworkCore;
using sqlink.Models;
namespace sqlink.Data;

public class InsuranceDbContext : DbContext
{
  public InsuranceDbContext(DbContextOptions<InsuranceDbContext> options) : base(options)
  {
  }

  public DbSet<User> Users { get; set; }
  public DbSet<InsurancePolicy> InsurancePolicies { get; set; }
}
