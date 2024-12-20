using System.Text;
using GameDataParser.Model;

namespace GameDataParser.UserInteraction;

public class GamesDataPrinter : IGamesDataPrinter
{
    private readonly  IUserInteractor _userInteractor;

    public GamesDataPrinter(IUserInteractor userInteractor)
    {
        _userInteractor = userInteractor;
    }

    public void Print(List<GameData> gameDatas)
    {
        if (gameDatas.Count > 0)
        {
            // Write the text to the console.
            _userInteractor.PrintMessage(Environment.NewLine + "Loaded games are:");
            var builder = new StringBuilder();
            
            foreach (var gameData in gameDatas)
            {
                builder.AppendLine(gameData.ToString());
            }

            _userInteractor.PrintMessage(builder.ToString());
        }
        else
        {
            _userInteractor.PrintMessage("No games are present in the input file.");
        }
    }
}