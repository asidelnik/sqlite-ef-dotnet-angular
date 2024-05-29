using Microsoft.EntityFrameworkCore;
using sqlink.Models;

namespace sqlink.Data;
public class InsuranceDbContext : DbContext
{
  protected readonly IConfiguration Configuration;

  public InsuranceDbContext(IConfiguration configuration)
  {
    Configuration = configuration;
  }

  protected override void OnConfiguring(DbContextOptionsBuilder options)
  {
    options.UseSqlite("Data Source=app.db");
    options.UseSqlite(Configuration.GetConnectionString("DefaultConnection"));
  }

  public DbSet<User> Users { get; set; }
  public DbSet<InsurancePolicy> InsurancePolicies { get; set; }
}
