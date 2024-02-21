using System.ComponentModel.DataAnnotations;

namespace CareFinder.API.DTOs.User;

public class ApiUserDto : LoginDto
{
  [Required]
  public string FirstName { get; set; }

  [Required]
  public string LastName { get; set; }

}
