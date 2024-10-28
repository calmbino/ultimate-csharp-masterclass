namespace SimpleCalculator;

internal class Calculator
{
    private string Name { get; }
    private string Symbol { get; }
    private Func<int, int, int> OperationFunc { get; }

    private Calculator(string name, string symbol, Func<int, int, int> operationFunc)
    {
        Name = name;
        Symbol = symbol;
        OperationFunc = operationFunc;
    }

    public void Perform(int firstNumber, int secondNumber)
    {
        int result = OperationFunc(firstNumber, secondNumber);
        Console.WriteLine($"{firstNumber} {this.Symbol} {secondNumber} = {result}");
    }

    
    public static readonly Calculator Add = new Calculator("Addition", "+", (x, y) => x + y);
    public static readonly Calculator Substract = new Calculator("Substraction", "-", (x, y) => x - y);
    public static readonly Calculator Multiply = new Calculator("Multiplication", "*", (x, y) => x * y);
}