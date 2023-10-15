using System.Diagnostics.Metrics;
using System.Reflection.Emit;

namespace TinaLutticms23C_Sharp.Models;

public class Address // klassen, strukturen för min adress, bestämmer hur ett objekt får skapas

    {
    public string? StreetName { get; set; } //get hämtar värdet som användaren anget, set tillåter användaren att ge ett värde tex gatuadress
    public string? StreetNumber { get; set; } // string pga kan vara både siffror och bokstav osv
    public string? PostalCode { get; set; }//?= för att det kan lämnas tomt
    public string? City { get; set; }

        public override string ToString() 
    {
            return $"{StreetName} {StreetNumber}, {PostalCode} {City}"; //returnerar hela adressen
    }
    }
// Eftersom konsolen skrev ut "TinaLutticms23C_Sharp.Models.Address" i stället för adressen jag skrev i konsolen
//gör så överskrider detta och returnerar adressen som användaren anger i konsolen 
