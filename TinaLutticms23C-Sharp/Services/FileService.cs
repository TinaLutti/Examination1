namespace TinaLutticms23C_Sharp.Services;

public class FileService        //Service för att lägga till fil
{

    private static readonly string filePath = @"C:\Users\Tian_\OneDrive\Skrivbord\Json.txt";

    public static void SaveToFile(string contentAsJson)
    {
        try
        {
            using var writer = new StreamWriter(filePath);
            writer.WriteLine(contentAsJson);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ett fel uppstod när data skulle sparas: " + ex.Message);  //om ej kan spara till fill får ett felmeddelande
        }
    }

    public static string ReadFromFile()
    {
        if (File.Exists(filePath))
        {
            using var reader = new StreamReader(filePath);
            return reader.ReadToEnd();
        }
        return null!;
    }
}



