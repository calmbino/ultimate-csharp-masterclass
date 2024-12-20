using System.Runtime.ExceptionServices;
using System.Text.Json;
using GameDataParser.Model;
using GameDataParser.UserInteraction;

namespace GameDataParser.DataAccess;

public class GameDatasDeserializer : IGameDatasDeserializer
{
    private readonly IUserInteractor _userInteractor;

    public GameDatasDeserializer(IUserInteractor userInteractor)
    {
        _userInteractor = userInteractor;
    }

    public List<GameData> DeserializeFrom(string fileName, string jsonString)
    {
        try
        {
            return JsonSerializer.Deserialize<List<GameData>>(jsonString);
        }
        catch (JsonException ex)
        {
            _userInteractor.PrintError($"JSON in the {fileName} was not in a valid format. JSON body: ");
            _userInteractor.PrintError(jsonString);
            
            // 원본 예외의 스택 트레이스는 유지하면서 메시지를 업데이트
            throw new EnhancedJsonException($"{ex.Message} The file is: {fileName}", ex);
        }

    }
}

public class EnhancedJsonException : JsonException
{
    public EnhancedJsonException(string message, Exception inner) : base(message, inner)
    {
        // InnerException을 통해 원본 스택 트레이스를 보존
        ExceptionDispatchInfo.Capture(inner).Throw();
    }
}