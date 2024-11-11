namespace CookiesCookbook.FileAccess;

public static class FileForamtExtensions
{
    public static string AsFileExtension(this FileFormat fileForm) => fileForm == FileFormat.Json ? "json" : "txt";
}