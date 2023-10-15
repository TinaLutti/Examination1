using TinaLutticms23C_Sharp.Interfaces;
using TinaLutticms23C_Sharp.Models;


namespace TinaLutticms23C_Sharp.Services;

public class MenuService : IMenuService
{
    private readonly ContactService _contactService = new ContactService(); // Skapa en instans av ContactService som hanterar kontakter

    public void MainMenu()
    {
        while (true) //  loop för att hålla programmet igång
        {
            Console.Clear();
            Console.WriteLine("Kontakter:");
            Console.WriteLine("...............");
            Console.WriteLine();
            Console.WriteLine("Välj något av alternativen");
            Console.WriteLine();
            Console.WriteLine("1. Lägg till en kontakt");
            Console.WriteLine("2. Se alla kontakter");
            Console.WriteLine("3. Se en kontakt");
            Console.WriteLine("4. Ta bort en kontakt");
            Console.WriteLine("5. Avsluta");

            int option;
            while (!int.TryParse(Console.ReadLine(), out option) || option < 1 || option > 5) //mindre är ett el mer än 5 loopen blir false
            {
                Console.Write("Något blev fel, välj ett nummer mellan 1-5: ");
            }

            switch (option)
            {
                case 1:
                    AddContact();
                    break;
                case 2:
                    GetAllContacts();
                    break;
                case 3:
                    GetOneContact();
                    break;
                case 4:
                    DeleteContact();
                    break;
                case 5:
                    Environment.Exit(0); // Använd "0" för att avsluta programmet korrekt
                    break;
                default:
                    break;
            }
        }

    }


    public void AddContact() //nedan fyller användaren i konatktuppgifter
    {
        var contact = new Contact(); // Skapa en ny kontaktinstans

        Console.Clear();
        Console.WriteLine("Lägg till en kontakt");
        Console.WriteLine("....................");
        Console.Write("Förnamn: ");
        contact.FirstName = Console.ReadLine();
        Console.Write("Efternamn: ");
        contact.LastName = Console.ReadLine();
        Console.Write("Email: ");
        contact.Email = Console.ReadLine();
        Console.Write("Telefonnummer: ");
        contact.PhoneNumber = Console.ReadLine();

        var contactAddress = new Address(); // Skapa en instans för adress

        Console.Write("Gata: ");
        contactAddress.StreetName = Console.ReadLine();
        Console.Write("Gatunummer: ");
        contactAddress.StreetNumber = Console.ReadLine();
        Console.Write("Postnummer: ");
        contactAddress.PostalCode = Console.ReadLine();
        Console.Write("Stad/Ort: ");
        contactAddress.City = Console.ReadLine();

        contact.Address = contactAddress; // Koppla adressen till kontakten
        _contactService.AddContact(contact); // Lägg till kontakten i kontaktlistan som hanteras av _contactService

        Console.Clear();
        Console.WriteLine("Kontakten är tillagd. ");
        Console.ReadKey();
        MainMenu();
    }


    public void DeleteContact()
    {
        Console.Clear();
        Console.WriteLine("Ta bort en kontakt");
        Console.WriteLine("..............");
        Console.WriteLine();
        Console.Write("Ange email: ");
        var email = Console.ReadLine()!.Trim().ToLower(); // Läs in och formatera e-postadressen (till små bokstäver)

        Console.WriteLine();

        try
        {
            var contact = _contactService.GetOneContact(email); // Hämta kontakten via e-post

            if (contact != null) // Om kontakten inte är null (dvs. den hittades):
            {
                Console.WriteLine($"Namn: {contact.FirstName} {contact.LastName}");
                Console.WriteLine($"Email: {contact.Email}");
                Console.WriteLine($"Telefonnummer: {contact.PhoneNumber}");
                Console.WriteLine($"Adress: {contact.Address}");

                Console.WriteLine();
                Console.WriteLine("Vill du radera den här kontakten? (Ja/Nej):");
                var response = Console.ReadLine();
                Console.Clear();

                if (response?.Trim().Equals("Ja", StringComparison.OrdinalIgnoreCase) == true) // Om användaren svarar "Ja"
                {
                    _contactService.DeleteContact(email); // Radera kontakten från listan

                    Console.Clear();
                    Console.WriteLine("Kontakten är borttagen.");
                }
                else // Om användaren inte vill radera:
                {
                    Console.Clear();
                    Console.WriteLine("Ingen kontakt har raderats.");
                }
                Console.ReadKey();
                MainMenu();
            }
            else
            {
                Console.WriteLine("Kontakten kunde inte hittas."); // Om kontakten inte hittades
            }
        }
        catch       //catch om det blir fel
        {

        }
        Console.ReadKey();
        MainMenu();
    }

    public void GetAllContacts()
    {
        Console.Clear();
        Console.WriteLine("Se alla kontakter");
        Console.WriteLine("....................");
        Console.WriteLine();

        var contactList = _contactService.GetAllContacts();

        if (_contactService != null) // Om det finns kontakt sparat i _contactService händer nedanstående: 
        {
            foreach (var contact in contactList)
            {
                Console.WriteLine($"Namn: {contact.FirstName} {contact.LastName}");
                Console.WriteLine($"Email: {contact.Email}");
                Console.WriteLine($"Telefonnummer: {contact.PhoneNumber}");
                Console.WriteLine($"Adress: {contact.Address}");
                Console.WriteLine();
            }
        }
        else
        {
            Console.WriteLine("Det finns inga kontakter i kontaktlistan.");
        }
        Console.ReadKey();
        MainMenu();
    }

    public void GetOneContact()     //hämta en kontakt utefter emailadress
    {
        Console.Clear();
        Console.WriteLine("Se en kontakt");
        Console.WriteLine(".............");
        Console.WriteLine();
        Console.Write("Ange email: ");
        var email = Console.ReadLine();

        try
        {
            var contact = _contactService.GetOneContact(email!);
            if (contact != null)
            {
                Console.Clear();
                Console.WriteLine("Kontakt");
                Console.WriteLine(".............");
                Console.WriteLine($"Namn: {contact.FirstName} {contact.LastName}");
                Console.WriteLine($"Email: {contact.Email}");
                Console.WriteLine($"Telefonnummer: {contact.PhoneNumber}");
                Console.WriteLine($"Adress: {contact.Address}");

                Console.ReadKey();
                MainMenu();
            }
            else
            {
                Console.WriteLine("Kontakten kunde inte hittas.");
            }
        }
        catch
        {

        }
    }
}
    

  

