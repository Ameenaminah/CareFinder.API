using System.ComponentModel.DataAnnotations;

namespace CareFinder.API.DTOs.Hospital;

public class UpdateHospitalDto
{
  public int Id { get; set; }

  public string Email { get; set; }

  [Required]
  public string PhoneNumber { get; set; }
}
