using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CareFinder.API.Data.Configurations;

public class HospitalConfiguration : IEntityTypeConfiguration<Hospital>
{
  public void Configure(EntityTypeBuilder<Hospital> builder)
  {
    builder.HasData(
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
  }
}
