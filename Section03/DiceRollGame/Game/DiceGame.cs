using DiceRollGame.UserCommunication;

namespace DiceRollGame.Game;

public class DiceGame
{
    private int ChanceCount => 3;
    private readonly Dice _dice;

    public DiceGame(Dice dice)
    {
        _dice = dice;
    }
    
    public GameResult Play()
    {
        int diceRollResult = _dice.Roll();
        Console.WriteLine($"Dice rolled. Guess what number it shows in {ChanceCount} tries.");

        var triesLeft = ChanceCount;
        while (triesLeft > 0)
        {
            int inputNumber = ConsoleReader.ReadInteger("Enter a number: ");
            
            if (inputNumber == diceRollResult)
            {
                return GameResult.Win;
            }
            
            Console.WriteLine("Wrong number. ");
            --triesLeft;
        }

        return GameResult.Loose;
    }


    public static void PrintResult(GameResult result)
    {
        string message = result == GameResult.Win ? "You win! :)" : "You lose! :(";
        
        Console.WriteLine(message);
    }
}