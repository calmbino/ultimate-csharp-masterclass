using CookiesCookbook.Recipes;

namespace CookiesCookbook.App;

public class CookiesRecipesApp
{
    private readonly IRecipeRepository _recipeRepository;
    private readonly IRecipeUserInteraction _recipeUserInteraction;
    
    
    // private readonly List<Ingredient> _ingredients;
    // private  string FileName { get; } = "recipes";
    // private  string FileExtension { get; } = ".json";
    // private FileFormat Format { get; init; }


    // * Dependency Inversion => should depend on abstractions, not on concrete types.
    // * Dependency Injection => class is given the dependencies it needs. it doesn't create them itself.
    public CookiesRecipesApp(
        IRecipeRepository recipeRepository,
        IRecipeUserInteraction recipeUserInteraction
    )
    {
        _recipeRepository = recipeRepository;
        _recipeUserInteraction = recipeUserInteraction;
    }

    public void Run(string filePath)
    {
        var allRecipes = _recipeRepository.Read(filePath);
        _recipeUserInteraction.PrintExistingRecipes(allRecipes);

        _recipeUserInteraction.PromptToCreateRecipe();
        
        var ingredients = _recipeUserInteraction.ReadIngredientsFromUser();
        
        if (ingredients.Count() > 0)
        {
            var recipe = new Recipe(ingredients);
            allRecipes.Add(recipe);
            _recipeRepository.Write(filePath, allRecipes);
        
            _recipeUserInteraction.ShowMessage("Recipe added:");
            _recipeUserInteraction.ShowMessage(recipe.ToString());
        
        }
        else
        {
            _recipeUserInteraction.ShowMessage("No ingredients have been selected. " + "Recipe will not be saved.");
        }


        _recipeUserInteraction.Exit();
        
    }
}