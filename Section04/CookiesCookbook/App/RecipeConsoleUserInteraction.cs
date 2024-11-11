using CookiesCookbook.Recipes;
using CookiesCookbook.Recipes.Ingredients;

namespace CookiesCookbook.App;

public class RecipeConsoleUserInteraction: IRecipeUserInteraction
{
    private readonly IIngredientRegister _ingredientRegister;

    public RecipeConsoleUserInteraction(IIngredientRegister ingredientRegister)
    {
        _ingredientRegister = ingredientRegister;
    }



    public void PromptToCreateRecipe()
    {
        Console.WriteLine("Create a new cookie recipe! " + "Available ingredients are: ");

        foreach (var ingredient in _ingredientRegister.All)
        {
            Console.WriteLine(ingredient);
        }
        
    }

    public IEnumerable<Ingredient> ReadIngredientsFromUser()
    {
        bool shallStop = false;
        var ingredients = new List<Ingredient>();

        while (!shallStop)
        {
            Console.WriteLine("Add an ingredient by its ID, " + "or type anything else if finished.");
            
            var userInput = Console.ReadLine();

            if (int.TryParse(userInput, out int id))
            {
                var selectedIngredient = _ingredientRegister.GetById(id);
                if (selectedIngredient is not null)
                {
                    ingredients.Add(selectedIngredient);
                }
            }
            else
            {
                shallStop = true;
            }
        }
        
        return ingredients;
    }

    public void PrintExistingRecipes(object allRecipes)
    {
        throw new NotImplementedException();
    }
    

    public void ShowMessage(string message)
    {
        Console.WriteLine(message);
    }

    public void Exit()
    {
        Console.WriteLine("Press any key to close.");
        Console.ReadKey();
    }

    public void PrintExistingRecipes(IEnumerable<Recipe> allRecipes)
    {
        if (allRecipes.Count() > 0)
        {
            Console.WriteLine("Existing recipes are: " + Environment.NewLine);

            var count = 1;
            foreach (var recipe in allRecipes)
            {
                Console.WriteLine($"*****{count}*****");
                Console.WriteLine(recipe);
                Console.WriteLine();
                ++count;
            }
        }
    }
}