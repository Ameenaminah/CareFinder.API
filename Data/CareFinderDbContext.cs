using Microsoft.EntityFrameworkCore;

namespace CareFinder.API.Data;

public class CareFinderDbContext : DbContext
{
  public DbSet<Hospital> Hospitals { get; set; }
  public DbSet<Address> Addresses { get; set; }

  public CareFinderDbContext(DbContextOptions options) : base(options)
  {

  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);
    modelBuilder.Entity<Hospital>().HasData(
      new Hospital
      {
        Id = 1,
        Name = "Unilorin Teaching Hospital",
        Specialization = "General",
        Email = "aaa@kk.com",
        PhoneNumber = "12345",
        About = "asw dd ee eee fff vvv",
        Image = "ffff"
      },
      new Hospital
      {
        Id = 2,
        Name = "UniLag Teaching Hospital",
        Specialization = "General",
        Email = "aaa@kk.com",
        PhoneNumber = "12345",
        About = "asw dd ee eee fff vvv",
        Image = "sssssss"
      },
      new Hospital
      {
        Id = 3,
        Name = "UniAbuja Teaching Hospital",
        Specialization = "General",
        Email = "aaa@kk.com",
        PhoneNumber = "12345",
        About = "asw dd ee eee fff vvv",
        Image = "sssssss"
      }
    );

    modelBuilder.Entity<Address>().HasData(
      new Address
      {
        Id = 1,
        AddressLine = "22, saliu street",
        State = "Lagos",
        PostalCode = "1111",
        HospitalId = 3,
      },
      new Address
      {
        Id = 2,
        AddressLine = "24, saliu street",
        State = "Ogun",
        PostalCode = "1121",
        HospitalId = 1,
      },
      new Address
      {
        Id = 3,
        AddressLine = "26, saliu street",
        State = "Lagos",
        PostalCode = "1111",
        HospitalId = 2,
      }
    );
    // modelBuilder.ApplyConfiguration(new CountryConfiguration());
    // modelBuilder.ApplyConfiguration(new HotelConfiguration());
  }
}
