using System.Net;
using TinaLutticms23C_Sharp.Models;

namespace TinaLutticms23C_Sharp.Interfaces;

public interface IContact //Gränssnitt/kontrakt för contact
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public Address? Address { get; set; }           
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
}
