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
    

    public ContactService()
    {
        _contactList = GetFile(); // hämtar kontakter från fil 
    }

    public Contact AddContact(Contact contact) //lägg till kontakt
    {
        // Om listan inte finns, skapa en ny lista
        if (_contactList == null) 
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
        try
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
        catch (Exception ex)
        {
            // fånga och hantera undantaget här
            Console.WriteLine("Ett fel uppstod: " + ex.Message);
            return null!; // Returnera null om något går fel
        }
    }

        public Contact GetOneContact(string email)  // för att hämta ut en kontakt via mailadress
    {
        try
        {   //om _contactList är null
            if (_contactList == null)
            {
                //skapas en ny lista Contact
                _contactList = new List<Contact>();
            }
            // hämtar ut från listan via email, om ingen mail matchar skickas null
            var contact = _contactList?.FirstOrDefault(x => x.Email == email); 
            
            //gjort try catch för att slippa varningen "may be null" men löstes ej
            return contact; // skickar tillbaka kontakten; om ej kontakten hittas, returneras null.
        }
        catch (Exception ex)
        {
            // fånga och hantera undantaget här
            Console.WriteLine("Ett fel uppstod: " + ex.Message);
            return null!; // Returnera null om något går fel
        }
    }

    public List<Contact> GetFile()
    {
        var file = FileService.ReadFromFile();  //läser från fil
        if (string.IsNullOrEmpty(file))
        {
            return new List<Contact>();
        }

        var deserializedContacts = JsonConvert.DeserializeObject<List<Contact>>(file); //konverterar json till kontaktlista GÖR EN TRY CATCH!
        return deserializedContacts ?? new List<Contact>(); //skickar tom lista om ej fungerar. ??=annars
    }

}
