namespace GameDataParser.UserInteraction;

public interface IUserInteractor
{
    string ReadValidFilePath(string path);
    void PrintMessage(string message);
    void PrintError(string message);
}