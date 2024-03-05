using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;


namespace CareFinder.API.Data;

public class Address
{
  public int Id { get; set; }
  public string AddressLine { get; set; } 
  public string State { get; set; } 
  public string PostalCode { get; set; } 

  [ForeignKey(nameof(Hospital))]
  public int HospitalId { get; set; }
  public Hospital Hospital { get; set; }
}
