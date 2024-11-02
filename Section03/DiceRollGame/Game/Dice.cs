namespace DiceRollGame.Game;

public class Dice
{
    private readonly int _sideCount;
    private readonly Random _random;

    public Dice(Random random, int sideCount)
    {
        _random = random;
        _sideCount = sideCount;
    }

    public int Roll() => _random.Next(1, _sideCount + 1);
}