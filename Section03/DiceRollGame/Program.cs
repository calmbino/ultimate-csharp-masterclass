using DiceRollGame.Game;

namespace DiceRollGame;

class Program
{
    static void Main(string[] args)
    {
      var random = new Random();
      var dice = new Dice(random, 6);
      var game = new DiceGame(dice);

      GameResult gameResult = game.Play();
      DiceGame.PrintResult(gameResult);
    }
}