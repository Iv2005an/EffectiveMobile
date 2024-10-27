using CsvHelper;
using EffectiveMobileConsole.Models;
using System.Globalization;

namespace EffectiveMobileConsole.Services;

public static class LogService
{
    const string logFile = "logs.csv";
    static string logPath = "";

    public static string LogPath
    {
        get => Path.GetFullPath(Path.Combine(logPath, logFile));
        set
        {
            string path = Path.GetFullPath(value);
            if (Directory.Exists(path)) logPath = path;
            else throw new Exception($"Invalid path {path}");
        }
    }

    public static void Log(LogEvent logEvent)
    {
        switch (logEvent.Level)
        {
            case LogEvent.LogLevels.Info:
                PrintService.PrintInfoMessage(logEvent.Message);
                break;
            case LogEvent.LogLevels.Warning:
                PrintService.PrintWarningMessage(logEvent.Message);
                break;
            case LogEvent.LogLevels.Error:
                PrintService.PrintErrorMessage(logEvent.Message);
                break;
        }
        bool isAppend = File.Exists(LogPath);
        using StreamWriter writer = new(LogPath, isAppend);
        using CsvWriter csv = new(writer, CultureInfo.InvariantCulture);
        if (!isAppend)
        {
            csv.WriteHeader<LogEvent>();
            csv.NextRecord();
        }
        csv.WriteRecord(logEvent);
        csv.NextRecord();
    }
}
