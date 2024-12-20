using GameDataParser.Model;

namespace GameDataParser.UserInteraction;

public interface IGamesDataPrinter
{
    void Print(List<GameData> gameDatas);
}