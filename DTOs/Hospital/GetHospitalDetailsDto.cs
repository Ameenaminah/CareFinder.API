using CareFinder.API.DTOs.Address;

namespace CareFinder.API.DTOs.Hospital;

public class GetHospitalDetailsDto : BaseHospitalDto
{
  public string Id { get; set; }
  public string About { get; set; }
  public string Image { get; set; }
  public ICollection<AddressDto> Addresses { get; set; }
}

