using System.Net;
using TinaLutticms23C_Sharp.Interfaces;

namespace TinaLutticms23C_Sharp.Models;

public class Contact : IContact
{
    public Guid Id { get; set; } = Guid.NewGuid(); //unikt id för användaren
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public Address? Address { get; set; }      //Använder klassen address för att hämta properties för adress
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
}
