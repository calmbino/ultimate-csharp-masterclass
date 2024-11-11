using System.Text.Json;

namespace CookiesCookbook.DataAccess;

class StringJsonRepository: StringRepository
{

    protected override List<string> TextToStrings(string fileContent)
    {
        return JsonSerializer.Deserialize<List<string>>(fileContent);
    }

    protected override string StringsToText(List<string> strings)
    {
        return JsonSerializer.Serialize(strings);
    }
}