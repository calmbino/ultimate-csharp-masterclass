using System.Globalization;
using System.Text;

public class Logger
{
    private readonly string _logFileName;

    public Logger(string logFileName)
    {
        _logFileName = logFileName;
    }

    public void Log(Exception ex)
    {
        DateTime now = DateTime.Now;
        string formattedDate = now.ToString("F", new CultureInfo("ko-KR"));

        var builder = new StringBuilder();

        builder.AppendLine($"[{formattedDate}]");
        builder.AppendLine($"Exception message: {ex.Message}");
        builder.AppendLine($"Stack trace: {ex.StackTrace}");
        builder.AppendLine();
        
        // 로그 파일 남기기
        using (StreamWriter outputFile = new StreamWriter(_logFileName, true))
        {
            outputFile.WriteLine(builder.ToString());
        }
    }
}