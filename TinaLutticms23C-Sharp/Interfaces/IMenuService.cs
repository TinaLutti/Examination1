namespace TinaLutticms23C_Sharp.Interfaces;

public interface IMenuService //kontraktet för min meny
{
    public void MainMenu(); //huvudmeny där användaren kan göra sina val 
    public void AddContact(); //lägg till kontakt i listan
    public void DeleteContact(); //ta bort kontakt fårn listan
    public void GetAllContacts(); //visa alla kontakter i listan
    public void GetOneContact(); //visa en kontakt med angiven info i listan 
}
