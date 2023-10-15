using TinaLutticms23C_Sharp.Models;

namespace TinaLutticms23C_Sharp.Interfaces;

    public interface IContactService
    {
        public Contact AddContact(Contact contact); //lägger till kontakt i contact och returnerar tillagd kontakt
        public void DeleteContact(string email);    //Ta bort kontakt utifrån emailadress
        IEnumerable<Contact> GetAllContacts();  //hämtar alla kontakter i en lista som kan läsas och sorteras
        public Contact GetOneContact(string email); //Hämtar specifik kontakt utefter epostadress
    }
