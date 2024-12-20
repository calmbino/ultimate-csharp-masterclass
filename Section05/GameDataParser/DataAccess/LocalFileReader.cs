namespace GameDataParser.DataAccess;

public class LocalFileReader : IFileReader
{
    public string ReadFile(string filePath)
    {
        // Open the text file using a stream reader.
        using StreamReader reader = new(filePath);
        // Read the stream as a string.
        var jsonString = reader.ReadToEnd();
        return jsonString;
    }
}