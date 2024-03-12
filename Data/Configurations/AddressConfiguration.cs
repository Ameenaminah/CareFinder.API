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
  },
  new Address
  {
    Id = 4,
    AddressLine = "Ishaga Rd,Idi-Araba",
    State = "Lagos",
    PostalCode = "102215",
    HospitalId = 4
  },
  new Address
  {
    Id = 5,
    AddressLine = "57 Campbell St, Lagos Island",
    State = "Lagos",
    PostalCode = "101001",
    HospitalId = 5
  },
  new Address
  {
    Id = 6,
    AddressLine = "7 Ogalade Close off Ologun Agbaje Street, Victoria Island",
    State = "Lagos",
    PostalCode = "101001",
    HospitalId = 6
  },
  new Address
  {
    Id = 7,
    AddressLine = "2A Keffi Street, By Toyan St",
    State = "Lagos",
    PostalCode = "101233",
    HospitalId = 7
  },
  new Address
  {
    Id = 8,
    AddressLine = "17B Bourdillon Rd, Ikoyi",
    State = "Lagos",
    PostalCode = "106104",
    HospitalId = 8
  },
  new Address
  {
    Id = 9,
    AddressLine = "22 Abioro St, Ikate, Lekki",
    State = "Lagos",
    PostalCode = "106104",
    HospitalId = 9
  },
  new Address
  {
    Id = 10,
    AddressLine = "67 Oduduwa Cres, Ikeja GRA, Ikeja",
    State = "Lagos",
    PostalCode = "101233",
    HospitalId = 10
  },
  new Address
  {
    Id = 11,
    AddressLine = "45 New Umuahia Rd, Umu Okahia, Aba",
    State = "Abia",
    PostalCode = "453106",
    HospitalId = 11
  },
  new Address
  {
    Id = 12,
    AddressLine = "7 Ogalade Close off Ologun Agbaje Street, Victoria Island",
    State = "Lagos",
    PostalCode = "101001",
    HospitalId = 12
  }
);
  }
}
