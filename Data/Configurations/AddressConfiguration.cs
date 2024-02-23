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
    AddressLine = "20A Thompson Ave, Ikoyi",
    State = "Lagos",
    PostalCode = "106104",
    HospitalId = 1,
  },
  new Address
  {
    Id = 2,
    AddressLine = "3/5 Adetola Ayeni St, off Freedom Way, Lekki Phase I",
    State = "Lagos",
    PostalCode = "105102",
    HospitalId = 2,
  },
  new Address
  {
    Id = 3,
    AddressLine = "39 Isaac John str, GRA,Ikeja",
    State = "Lagos",
    PostalCode = "106104",
    HospitalId = 3,
  }
);
  }
}
