using CookiesCookbook.App;
using CookiesCookbook.DataAccess;
using CookiesCookbook.FileAccess;
using CookiesCookbook.Recipes;
using CookiesCookbook.Recipes.Ingredients;


namespace CookiesCookbook;

class Program
{
    private const FileFormat Format = FileFormat.Json;
    private const string FileName = "recipes";

    static void Main(string[] args)
    {
        IStringRepository stringRepository = 
            Format == FileFormat.Json ? new StringJsonRepository() : new StringTextualRepository();
        var fileMetadata = new FileMetadata(FileName, Format);
        
        var ingredientsRegister = new IngredientRegister(); 
        
        var cookieRecipesApp = new CookiesRecipesApp(
            new RecipeRepository(stringRepository, ingredientsRegister),
            new RecipeConsoleUserInteraction(ingredientsRegister)
            );
        
        cookieRecipesApp.Run(fileMetadata.ToPath());
    }
}