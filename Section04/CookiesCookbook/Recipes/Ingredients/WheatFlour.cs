namespace CookiesCookbook.Recipes.Ingredients;

public class WheatFlour : Flour
{
    public override int Id => 1;
    public override string Name => "Wheat Flour";
    public override string PreparationInstructions => $"Sieve. {base.PreparationInstructions}";

}