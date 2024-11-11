namespace CookiesCookbook.DataAccess;

class StringTextualRepository: StringRepository
{
    private static readonly string Separator = Environment.NewLine;

    protected override List<string> TextToStrings(string fileContent)
    {
        return fileContent.Split(Separator).ToList();
    }

    protected override string StringsToText(List<string> strings)
    {
        return string.Join(Separator, strings);
    }
}