using CsvHelper.Configuration.Attributes;

namespace EffectiveMobileConsole.Models;

public class LogEvent
{
    public enum LogLevels
    {
        Info,
        Warning,
        Error
    }

    [Format("yyyy-MM-dd HH:mm:ss")]
    public DateTime LogDateTime { get; set; } = DateTime.Now;

    public required LogLevels Level { get; set; }

    public required string Message { get; set; }
}
