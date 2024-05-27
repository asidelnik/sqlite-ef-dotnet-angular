using Microsoft.EntityFrameworkCore;
using sqlink.Models;
namespace sqlink.Data;

public class InsuranceDbContext : DbContext
{
  public DbSet<User> Users { get; set; }
  public DbSet<InsurancePolicy> InsurancePolicies { get; set; }
  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    optionsBuilder.UseSqlite("Data Source=app.db");
  }
}
