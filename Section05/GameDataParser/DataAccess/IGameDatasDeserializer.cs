using GameDataParser.Model;

namespace GameDataParser.DataAccess;

public interface IGameDatasDeserializer
{
    List<GameData> DeserializeFrom(string fileName, string jsonString);
}