using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using TinaLutticms23C_Sharp.Interfaces;
using TinaLutticms23C_Sharp.Models;
using TinaLutticms23C_Sharp.Services;

namespace TinaLutticms23C_Sharp.Services;

public class ContactService : IContactService
{
    private List<Contact> _contactList = new List<Contact>(); // en privat lista som lagrar kontakter
    private List<IContact> iContactList = new List<IContact>();// ej tillgänligt utanför klassen 

    public ContactService()
    {
        _contactList = GetFile(); // hämtar kontakter från fil 
    }

    public Contact AddContact(Contact contact) //lägg till kontakt
    {
        if (_contactList == null) // Om listan inte finns, skapa en ny lista
        {
            _contactList = new List<Contact>(); // insatnsierar och lägger till en kontakt i listan
        }

        _contactList.Add(contact);
        var json = JsonConvert.SerializeObject(_contactList);  //omvandlar listan till json
        FileService.SaveToFile(json);  // sparar JSON-data i en fil
        return contact; //returnerar kontakten
    }

    public void DeleteContact(string email) //tar bort kontakt genom mailadress
    {
        if (_contactList == null)
        {
            _contactList = new List<Contact>();
        }

        var contact = GetOneContact(email); // hämtar kontakten via mail som ska tas bort
        if (contact != null)
        {
            _contactList.Remove(contact);   //tar bort kontakten från listan
            var json = JsonConvert.SerializeObject(_contactList);
            FileService.SaveToFile(json);
        }
    }

    public IEnumerable<Contact> GetAllContacts()
    {
        if (_contactList == null)
        {
            _contactList = new List<Contact>();
        }

        var file = FileService.ReadFromFile(); //läser från listan
        if (!string.IsNullOrEmpty(file))
        {
            var deserializedContacts = JsonConvert.DeserializeObject<List<Contact>>(file);
            if (deserializedContacts != null)
            {
                _contactList = deserializedContacts; //uppdaterar listan
            }
        }

        return _contactList.OrderBy(contact => contact.FirstName); //ger tillbaka listan sorterad på förnamn
    }

    public Contact GetOneContact(string email)  //för att hämta ut en kontakt via mailadress
    {
        if (_contactList == null)
        {
            _contactList = new List<Contact>();
        }

        var contact = _contactList.FirstOrDefault(x => x.Email == email); //hämtar ut fr listan via email
        return contact; //skickar tillbaka kontakten
    }

    public List<Contact> GetFile()
    {
        var file = FileService.ReadFromFile();  //läser från fil
        if (string.IsNullOrEmpty(file))
        {
            return new List<Contact>();
        }

        var deserializedContacts = JsonConvert.DeserializeObject<List<Contact>>(file); //konverterar json till kontaktlista
        return deserializedContacts ?? new List<Contact>(); //skickar tom lista om ej fungerar
    }

}
