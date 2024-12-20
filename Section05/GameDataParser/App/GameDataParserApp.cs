using GameDataParser.DataAccess;
using GameDataParser.UserInteraction;

namespace GameDataParser.App;

public class GameDataParserApp
{
    private readonly IUserInteractor _userInteractor;
    private readonly IGamesDataPrinter _gamesDataPrinter;
    private readonly IGameDatasDeserializer _gameDatasDeserializer;
    private readonly IFileReader _fileReader;

    public GameDataParserApp(IUserInteractor userInteractor, IGamesDataPrinter gamesDataPrinter, IGameDatasDeserializer gameDatasDeserializer, IFileReader fileReader)
    {
        _userInteractor = userInteractor;
        _gamesDataPrinter = gamesDataPrinter;
        _gameDatasDeserializer = gameDatasDeserializer;
        _fileReader = fileReader;
    }

    public void Run()
    {
        var defaultPath = "JsonFiles";
        var fileName = _userInteractor.ReadValidFilePath(defaultPath);
        var filePath = $"{defaultPath}/{fileName}";
        var jsonString = _fileReader.ReadFile(filePath);
        var gameDatas = _gameDatasDeserializer.DeserializeFrom(fileName, jsonString);
        _gamesDataPrinter.Print(gameDatas);
    }
}