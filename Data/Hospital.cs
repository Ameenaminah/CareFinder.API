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
  public string Website { get; set; } = "https://www.google.com/";
  public string Image { get; set; } = "https://png.pngtree.com/png-vector/20191030/ourmid/pngtree-hospital-icon-png-image_1922195.jpg";
  public ICollection<Address> Addresses { get; set; }
}
