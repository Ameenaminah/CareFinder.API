namespace CareFinder.API.DTOs.Address;

public class AddressDto
{
  public int Id { get; set; }
  public string AddressLine { get; set; }
  public string State { get; set; }
  public string PostalCode { get; set; }
  public int HospitalId { get; set; }
}
