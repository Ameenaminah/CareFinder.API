namespace CareFinder.API.Data;

public class Hospital
{

  public int Id { get; set; }
  public string Name { get; set; } 
  public string Specialization { get; set; } 
  public string Ownership { get; set; } 
  public string Email { get; set; } 
  public string PhoneNumber { get; set; } 
  public string About { get; set; } 
  public string Website { get; set; } 
  public string Image { get; set; } 
  public ICollection<Address> Addresses { get; set; }
}
