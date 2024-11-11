namespace CookiesCookbook.Recipes;

public interface IRecipeRepository
{
    List<Recipe> Read(string filePath);
    void Write(string filePath, List<Recipe> allRecipes);
}