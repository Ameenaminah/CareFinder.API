using CareFinder.API.Data.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CareFinder.API.Data;

public class CareFinderDbContext : IdentityDbContext<ApiUser>
{
  public DbSet<Hospital> Hospitals { get; set; }
  public DbSet<Address> Addresses { get; set; }

  public CareFinderDbContext(DbContextOptions options) : base(options)
  {
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);
    modelBuilder.ApplyConfiguration(new RoleConfiguration());
    modelBuilder.ApplyConfiguration(new HospitalConfiguration());
    modelBuilder.ApplyConfiguration(new AddressConfiguration());
  }
}
