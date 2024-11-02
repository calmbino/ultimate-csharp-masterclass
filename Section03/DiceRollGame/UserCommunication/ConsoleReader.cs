namespace DiceRollGame.UserCommunication;

public static class ConsoleReader
{
    public static int ReadInteger(string message)
    {
        bool parsedResult;
        int inputNumber;
        do
        {
            Console.Write(message);
            parsedResult = int.TryParse(Console.ReadLine(), out inputNumber);

            if (!parsedResult)
            {
                Console.WriteLine("Please enter a valid integer.");
            }

        } while (!parsedResult);
        
        return inputNumber;
    }
}