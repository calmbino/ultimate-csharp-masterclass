namespace SimpleCalculator;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello!");
        
        if(!TryGetNumber("Input the first number", out int firstNumber) || 
            !TryGetNumber("Input the second number", out int secondNumber))
        {
            Exit("Invalid input.");
            return;
        }


        Calculator? calculator = GetCalcualtor();
        
        if (calculator == null)
        {
            Exit("Invalid choice.");
            return;
        }
        
        calculator.Perform(firstNumber, secondNumber);
        
        Exit();    
    }

    private static bool TryGetNumber(string message, out int number)
    {
        Console.WriteLine(message);
        return int.TryParse(Console.ReadLine(), out number);
    }

    private static Calculator? GetCalcualtor()
    {
        Console.WriteLine("""
                          What do you want to do?
                          [A]dd numbers
                          [S]ubstract numbers
                          [M]ultiply numbers
                          """);
        
        string? input = Console.ReadLine()?.ToUpper();
        
        return input switch
        {
            "A" => Calculator.Add,
            "S" => Calculator.Substract,
            "M" => Calculator.Multiply,
            _ => null
        };
    }
    

    private static void Exit(string? message = null)
    {
        Console.WriteLine(message);
        
        Console.WriteLine("Press any key to close.");
        Console.ReadKey();
    }
}