using System.ComponentModel.DataAnnotations;

namespace CareFinder.API.DTOs.Hospital;

public class CreateHospitalDto : BaseHospitalDto
{
  public string Website { get; set; } = "https://www.google.com/";
  [Required]
  public string About { get; set; }
  public string Image { get; set; } = "https://png.pngtree.com/png-vector/20191030/ourmid/pngtree-hospital-icon-png-image_1922195.jpg";
}
