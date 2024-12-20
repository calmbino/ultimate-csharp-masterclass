using System.Globalization;
using System.Text;
using System.Text.Json;

bool isContinue = true;
string jsonString = String.Empty;

while (isContinue)
{
    Console.WriteLine("Enter the name of the file you want to read:");
    var input = Console.ReadLine();

    if (input == null)
    {
        Console.WriteLine("File name cannot be null.");
        continue;
    }
        
    if (input == String.Empty)
    {
        Console.WriteLine("Filen name cannot be empty.");
        continue;
    }

    try
    {
        // Open the text file using a stream reader.
        using StreamReader reader = new($"JsonFiles/{input}");
        // Read the stream as a string.
        jsonString = reader.ReadToEnd();


        var gameDatas = JsonSerializer.Deserialize<GameData[]>(jsonString);

        // Write the text to the console.
        Console.WriteLine("Loaded games are:");
        var builder = new StringBuilder();
        foreach (var gameData in gameDatas)
        {
            builder.AppendLine($"{gameData.Title}, released in {gameData.ReleaseYear}, rating: {gameData.Rating}");
        }

        Console.WriteLine(builder.ToString());
        Console.WriteLine("Press any key to close");
        Console.ReadKey();
        isContinue = false;
    }
    catch (IOException e)
    {
        Console.WriteLine("The file could not be read:");
        Console.WriteLine(e.Message);
    }
    catch (JsonException e)
    {
        // 로그 파일 남기기
        using (StreamWriter outputFile = new StreamWriter("log.txt", true))
        {
            
            DateTime now = DateTime.Now;

            // Culture를 명시적으로 설정하여 출력
            string formattedDate = now.ToString("F", new CultureInfo("ko-KR"));
            outputFile.WriteLine($"[{formattedDate}]");
            outputFile.WriteLine($"Exception message: {e.Message}");
            outputFile.WriteLine($"The file is: {input}");
            outputFile.WriteLine(e.StackTrace);
            outputFile.WriteLine();
        }
        
        // 출력
        Console.WriteLine($"JSON in the {input} was not in a valid format. JSON body: ");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(jsonString);
        Console.ResetColor();
        Console.WriteLine("Sorry! The application has experienced an unexpected error and will have to be closed.");
        Console.WriteLine("Press any key to close");
        Console.ReadKey();
        isContinue = false;
    }
}

public class GameData
{
    public required string Title { get; set; }
    public required int ReleaseYear { get; set; }
    public required double Rating { get; set; }
}
