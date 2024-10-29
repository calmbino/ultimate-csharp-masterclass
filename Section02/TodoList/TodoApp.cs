namespace TodoList;

internal class TodoApp
{
    private List<string> _todos;
    private static readonly Lazy<TodoApp> _instance = new Lazy<TodoApp>(() => new TodoApp());
    
    private TodoApp()
    {
        _todos = new List<string>();
    }

    public static TodoApp GetInstance()
    {
        return _instance.Value;
    }

    public void Perform(TodoOperationType operation)
    {
        Action action = operation switch
        {
            TodoOperationType.See => See,
            TodoOperationType.Add => Add,
            TodoOperationType.Remove => Remove,
            _ => throw new ArgumentOutOfRangeException()
        };

        action(); 
    }
    
    private void See()
    {
        if (_todos.Count == 0)
        {
            Console.WriteLine("The TODO List is empty.");
            return;
        }
        
        for (int i = 0; i < _todos.Count; i++)
        {
            Console.WriteLine($"{i+1}. {_todos[i]}");
        }
        
        // 다음과 같은 방법으로도 구현 가능!
        //Console.WriteLine(_todos.Count == 0 ? "The TODO List is empty." : string.Join(Environment.NewLine, _todos.Select((todo, i) => $"{i + 1}. {todo}")));
    }

    private void Add()
    {
        string userInput;
        do
        {
            Console.WriteLine("Enter the TODO description: ");

            userInput = Console.ReadLine() ?? string.Empty;

        } while(!IsDescriptionValid(userInput));

        _todos.Add(userInput);
        Console.WriteLine($"TODO successfully added: {userInput}");
    }


    private void Remove()
    { 
        int index;
        do
        {
            Console.WriteLine("Select the index of the TODO you want to remove");
            See();
            
        } while (!TryGetIndex(out index));

        RemoveTodoAtIndex(index-1);
    }
    
    private void RemoveTodoAtIndex(int index)
    {
        Console.WriteLine($"TODO removed: {_todos[index]}");
        _todos.RemoveAt(index);
    }
    
    private bool IsDescriptionValid(string userInput)
    {
        if (string.IsNullOrEmpty(userInput) || string.IsNullOrWhiteSpace(userInput))
        {
            Console.WriteLine("The description cannot be empty.");
            return false;
        }
        else if (_todos.Contains(userInput))
        {
            Console.WriteLine("The description must be unique.");
            return false;
        }
        
        return true;
    }
    
    private bool TryGetIndex(out int index)
    {
        string userInput = Console.ReadLine() ?? string.Empty;

        if (string.IsNullOrEmpty(userInput) || string.IsNullOrWhiteSpace(userInput))
        {
            index = 0;
            Console.WriteLine("Selected index cannot be empty.");
            return false;
        }

        if (int.TryParse(userInput, out index) && index > 0 && index <= _todos.Count) return true;
        
        Console.WriteLine("The given index is not valid.");
        return false;
    }

}

internal enum TodoOperationType
{
    See,
    Add,
    Remove,
    Exit
}