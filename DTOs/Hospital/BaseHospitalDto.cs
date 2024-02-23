using System.ComponentModel.DataAnnotations;

namespace CareFinder.API.DTOs.Hospital;

public class BaseHospitalDto
{
  [Required]
  public string Name { get; set; }

  [Required]
  public string Specialization { get; set; }

  [Required]
  public string Ownership { get; set; }

  public string Email { get; set; }

  [Required]
  public string PhoneNumber { get; set; }
}
