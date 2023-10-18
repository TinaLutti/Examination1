using TinaLutticms23C_Sharp.Interfaces;
using TinaLutticms23C_Sharp.Models;
using TinaLutticms23C_Sharp.Services;
using Xunit; // Importera XUnit-ramverket

namespace ContactServiceTest.UnitTest;

    public class ContactService_Should
    {
        [Fact]
        public void AddContact_Should_AddOneContactToList_AndReturnTrue()       //test för att se om en kontakt läggs till listan
        {
         // Arrange förbereder mitt test
        IContactService contactService = new ContactService();// skapar en instans av ContactService
        Contact contact = new Contact(); // Skapar en instans av Contact

        contact.FirstName = ""; //anger förnamn på kontakten
        contact.LastName = ""; //anger efternamn på kontakten

         // Act utförande
         Contact result = contactService.AddContact(contact);           // anropar AddContact-metoden med kontakten

        // Assert kontroll
        Assert.True(result != null);                 // om resultatet inte är null, antas det att kontakten har lagts till
        Assert.Equal("", result.FirstName);         //testar förnamn
        Assert.Equal("", result.LastName);          //testar efternamn

        }
    }


