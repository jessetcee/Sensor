public class Logger
{
    private string logFilePath;

    public Logger(string filePath)
    {
        logFilePath = filePath;
    }

    public void LogData(string message)
    {
        string logEntry = $"{DateTime.Now}: {message}";
        File.AppendAllText(logFilePath, logEntry + Environment.NewLine);
    }
}
