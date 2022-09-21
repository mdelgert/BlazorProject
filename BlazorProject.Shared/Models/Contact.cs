namespace BlazorProject.Shared.Models;

public class Contact
{
    public int Contactid { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Address { get; set; } = null!;
    public string City { get; set; } = null!;
    public string State { get; set; } = null!;
    public string ZipCode { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
}
