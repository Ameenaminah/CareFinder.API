using AutoMapper;
using CareFinder.API.Data;
using CareFinder.API.DTOs.Address;
using CareFinder.API.DTOs.Hospital;

namespace CareFinder.API.Configurations;

public class MapperConfig: Profile
{
  public MapperConfig()
  {
    CreateMap<Hospital, CreateHospitalDto>().ReverseMap();
    CreateMap<Hospital, GetHospitalDto>().ReverseMap();
    CreateMap<Hospital, GetHospitalDetailsDto>().ReverseMap();
    CreateMap<Hospital, UpdateHospitalDto>().ReverseMap();
    
    CreateMap<Address, AddressDto>().ReverseMap();
    CreateMap<Address, CreateAddressDto>().ReverseMap();
    
  }
}

