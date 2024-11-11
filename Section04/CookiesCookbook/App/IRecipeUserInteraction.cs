using CookiesCookbook.Recipes;
using CookiesCookbook.Recipes.Ingredients;

namespace CookiesCookbook.App;

public interface IRecipeUserInteraction
{
    void ShowMessage(string message);
    void Exit();
    void PrintExistingRecipes(IEnumerable<Recipe> allRecipes);
    void PromptToCreateRecipe();
    IEnumerable<Ingredient> ReadIngredientsFromUser();
}