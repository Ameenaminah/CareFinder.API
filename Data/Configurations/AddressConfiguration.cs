using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CareFinder.API.Data.Configurations;

public class AddressConfiguration : IEntityTypeConfiguration<Address>
{
  public void Configure(EntityTypeBuilder<Address> builder)
  {
    builder.HasData(
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
  }
}
