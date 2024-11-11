using CookiesCookbook.DataAccess;
using CookiesCookbook.Recipes.Ingredients;

namespace CookiesCookbook.Recipes;

public class RecipeRepository: IRecipeRepository
{
    private readonly IStringRepository _stringRepository;
    private readonly IIngredientRegister _ingredientRegister;
    private const string Separator = ","; 

    public RecipeRepository(IStringRepository stringRepository, IIngredientRegister ingredientRegister)
    {
        _stringRepository = stringRepository;
        _ingredientRegister = ingredientRegister;
    }


    public List<Recipe> Read(string filePath)
    {
        List<string> recipesFromFile = _stringRepository.Read(filePath);
        var recipes = new List<Recipe>();

        foreach (var recipeFromFile in recipesFromFile)
        {
            var recipe = RecipeFromString(recipeFromFile);
            recipes.Add(recipe);
        }

        return recipes;
    }

    private Recipe RecipeFromString(string recipesFromFile)
    {
        var textualIds = recipesFromFile.Split(Separator);
        var ingredients = new List<Ingredient>();

        foreach (var textualId in textualIds)
        {
            var id = int.Parse(textualId);
            var ingredient = _ingredientRegister.GetById(id);
            ingredients.Add(ingredient);
        }

        return new Recipe(ingredients);
    }

    public void Write(string filePath, List<Recipe> allRecipes)
    {
        var recipesAsStrings = new List<string>();
        foreach (var recipe in allRecipes)
        {   
            var allIds = new List<int>();
            foreach (var ingredient in recipe.Ingredients)
            {
                allIds.Add(ingredient.Id);
            }
            recipesAsStrings.Add(string.Join(Separator, allIds));
        }
        
        _stringRepository.Write(filePath, recipesAsStrings);
    }
}