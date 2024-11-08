using System.Net.Mime;
using System.Text.Json;

namespace CookiesCookbook;

class Program
{
    static void Main(string[] args)
    {
        var cookbook = new CookiesCookbook(FileFormat.Text);
        
        cookbook.GenerateRecipe();
    }
}

abstract class Ingredient
{
    private static int _idCounter = 0;
    
    public int Id { get; }
    public virtual string Name { get; } = "Cookie's Ingredient";
    protected const string DefaultMessage = "Add to other ingredients";

    protected Ingredient(string name)
    {
        Id = ++_idCounter;
        Name = name;
    }
    
    public virtual string InstructionOfRecipe() => DefaultMessage;
}

class WheatFlour : Ingredient
{
    public WheatFlour() : base("Wheat Flour") {}


    public override string InstructionOfRecipe() => $"Sieve. {DefaultMessage}";
}

class CoconutFlour : Ingredient
{
    public CoconutFlour() : base("Coconut Flour") {}

    public override string InstructionOfRecipe() => $"Sieve. {DefaultMessage}";
}

class Butter : Ingredient
{
    public Butter() : base("Butter") {}

    public override string InstructionOfRecipe() => $"Melt on low heat. {DefaultMessage}";
}

class Chocolate : Ingredient
{
    public Chocolate() : base("Chocolate") {}
    
    public override string InstructionOfRecipe() => $"Melt in a water bath. {DefaultMessage}";

}

class Sugar : Ingredient
{
    public Sugar() : base("Sugar") {}

    public override string Name => "Sugar";
}

class Cardmom : Ingredient
{
    public Cardmom() : base("Cardmom") {}

    public override string InstructionOfRecipe() => $"Take half a teaspoon. {DefaultMessage}";

}

class Cinnamon : Ingredient
{
    public Cinnamon() : base("Cinnamon") {}


    public override string InstructionOfRecipe() => $"Take half a teaspoon. {DefaultMessage}";

}

class CocoaPowder : Ingredient
{
    public CocoaPowder() : base("Cocoa Powder") {}
}

enum FileFormat {
    Json,
    Text
}

class CookiesCookbook
{
    private readonly List<Ingredient> _ingredients;
    private  string FileName { get; } = "recipes";
    private  string FileExtension { get; } = ".json";
    private FileFormat Format { get; init; }


    public CookiesCookbook(FileFormat format = FileFormat.Json)
    {
        Format = format;
        FileExtension = Format == FileFormat.Json ? "json": "txt";
        _ingredients = InitializeIngredients();
    }

    public void GenerateRecipe()
    {
        List<List<int>> loadedRecipes = LoadRecipes();

        if (loadedRecipes.Count != 0)
        {
            Console.WriteLine("Existing recipes are:\n");
            int index = 0;
            foreach (var recipe in loadedRecipes)
            {
                List<Ingredient> ingredients = FindIngredientByIds(recipe);
                Console.WriteLine($"***** {++index} *****");
                DisplayRecipe(ingredients);
                Console.WriteLine();
            }

        }

        Console.WriteLine("Create a new cookie recipe! Available ingredients are:");
        DisplayIngredients(_ingredients);

        const int minId = 1;
        var maxId = _ingredients.Count;
        bool parsedResult;
        List<int> selectedIds = [];
        do
        {
            Console.WriteLine("Add an ingredient by it's ID or type anything else if finished.");
            parsedResult = int.TryParse(Console.ReadLine(), out var inputNumber);

            if (!parsedResult) break;
            
            if (inputNumber < minId || inputNumber > maxId)
            { 
                Console.WriteLine($"Please check the available IDs: {minId} ~ {maxId}");
                continue;
            }
            
            selectedIds.Add(inputNumber);
        } while (parsedResult);

        if (selectedIds.Count != 0)
        {
            var selectedIngredients = FindIngredientByIds(selectedIds);
            
            Console.WriteLine("Recipe added:");
            
            // 레시피가 만들어졌으면 출력해서 보여주기
            DisplayRecipe(selectedIngredients);
        
            // 저장
            SaveRecipe(selectedIds);
        }
        
        // 종료
        Console.WriteLine("\nPress any key to close.");
        Console.ReadKey();
    }

    private List<Ingredient> InitializeIngredients() =>
    [
        new WheatFlour(),
        new CoconutFlour(),
        new Butter(),
        new Chocolate(),
        new Sugar(),
        new Cardmom(),
        new Cinnamon(),
        new CocoaPowder()
    ];

    private static void DisplayIngredients(List<Ingredient> ingredients)
    {
        if (ingredients.Count == 0)
        {
            throw new ApplicationException("No ingredients have been added.");
        }
        
        foreach (var ingredient in ingredients)
        {
            Console.WriteLine($"{ingredient.Id}) {ingredient.Name}");
        }
    }

    private List<Ingredient> FindIngredientByIds(List<int> ids)
    {
        List<Ingredient> selectedIngredients = [];
        foreach (var id in ids)
        {
            var ingredient = _ingredients.Find(i => i.Id == id);
            if (ingredient != null) selectedIngredients.Add(ingredient);
        }

        return selectedIngredients;
    }

    private static void DisplayRecipe(List<Ingredient> ingredients) 
    {
        if (ingredients.Count == 0) return;

        foreach (var ingredient in ingredients)
        {
            Console.WriteLine($"{ingredient?.Name}. {ingredient?.InstructionOfRecipe()}");
        }
    } 

    private List<List<int>> LoadRecipes()
    {
        List<List<int>> loadedRecipes = [];
        
        if (File.Exists($"{FileName}.{FileExtension}"))
        {
            using (StreamReader sr = new StreamReader($"{FileName}.{FileExtension}"))
            {
                string line = sr.ReadLine();
                while (line != null)
                {
                    List<int> result = Format == FileFormat.Json
                        ? JsonSerializer.Deserialize<List<int>>(line)
                        : Array.ConvertAll(line.Split(','), int.Parse).ToList();
                    loadedRecipes.Add(result);
                
                    line = sr.ReadLine(); // 다음 줄 읽기
                }
            }
            Console.WriteLine();
        }
        
        return loadedRecipes;
    }

    private void SaveRecipe( List<int> ids)
    {

        string path = $"{FileName}.{FileExtension}";

        string result = Format == FileFormat.Json ? JsonSerializer.Serialize(ids) : string.Join(',', ids);

        // StreamWriter를 Append 모드로 열어 파일 끝에 내용을 추가합니다.
        using (StreamWriter writer = new StreamWriter(path, true))
        {
            writer.WriteLine(result); // 추가할 내용 작성
        }
    }
}

interface IFileManager
{
    void Save(string filename, string contents);
    
    void Load(string filename);
}

class JsonFileManager : IFileManager
{
    public void Save(string filename, string contents)
    {
        throw new NotImplementedException();
    }

    public void Load(string filename)
    {
        throw new NotImplementedException();
    }
}

class TextFileManager: IFileManager
{
    public void Save(string filename, string contents)
    {
        throw new NotImplementedException();
    }

    public void Load(string filename)
    {
        throw new NotImplementedException();
    }
}