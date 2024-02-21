using System.ComponentModel.DataAnnotations;

namespace CareFinder.API.DTOs.User;

public class LoginDto
{
  [Required]
  [EmailAddress]
  public string Email { get; set; }

  [Required(ErrorMessage = "Password is required")]
  [StringLength(15, ErrorMessage = "Password must be between 5 and 15 characters", MinimumLength = 5)]
  public string Password { get; set; }
}
