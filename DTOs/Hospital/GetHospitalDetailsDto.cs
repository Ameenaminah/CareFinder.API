using CareFinder.API.DTOs.Address;

namespace CareFinder.API.DTOs.Hospital;

public class GetHospitalDetailsDto : CreateHospitalDto
{
  public int Id { get; set; }
  public ICollection<AddressDto> Addresses { get; set; }
}

