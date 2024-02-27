using System.ComponentModel.DataAnnotations;

namespace CareFinder.API.DTOs.Address;

public abstract class BaseAddressDto
{
  [Required]
  public string AddressLine { get; set; }

  [Required]
  public string State { get; set; }

  public string PostalCode { get; set; }

  [Required]
  public string HospitalId { get; set; }
}
