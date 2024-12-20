namespace GameDataParser.UserInteraction;

public class ConsoleUserInteractor : IUserInteractor
{
    
    public string ReadValidFilePath(string path)
    {
        bool isFilePathValid = false;
        string fileName = default;
        do
        {
            Console.WriteLine("Enter the name of the file you want to read:");
            fileName = Console.ReadLine();
            
            if (fileName is null)
            {
                Console.WriteLine("File name cannot be null.");
                continue;
            }
                
            if (fileName == String.Empty)
            {
                Console.WriteLine("Filen name cannot be empty.");
                continue;
            }

            if (!File.Exists($"{path}/{fileName}"))
            {
                Console.WriteLine("The file does not exist.");
                continue;
            }
            
            isFilePathValid = true;
            
        } while (!isFilePathValid);
        
        return fileName;
    }

    public void PrintMessage(string message)
    {
        Console.WriteLine(message);
    }

    public void PrintError(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(message);
        Console.ResetColor();
    }
}