using System.ComponentModel.DataAnnotations;

namespace CareFinder.API.DTOs.Hospital;

public class CreateHospitalDto: BaseHospitalDto
{
  [Required]
  public string About { get; set; }

  [Required]
  public string Image { get; set; }
}
