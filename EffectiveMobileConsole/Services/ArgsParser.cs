using EffectiveMobileConsole.Exceptions;

namespace EffectiveMobileConsole.Services;

public class ArgsParser
{
    public ArgsParser(string[] args)
    {
        for (int i = 0; i < args.Length; i++)
        {
            switch (args[i])
            {
                case _cityDistrictArgName:
                    string cityDistrictS = args[++i];
                    try
                    {
                        CityDistrict = Convert.ToInt32(cityDistrictS);
                        break;
                    }
                    catch { throw new ArgsParserException($"Invalid city district index{cityDistrictS}"); }
                case _firstDeliveryDateTimeArgName:
                    string dateTimeS = args[++i];
                    try
                    {
                        string[] dateTime = dateTimeS.Split();
                        string dateS = dateTime[0];
                        string timeS = dateTime[1];
                        string[] date = dateS.Split('-');
                        string[] time = timeS.Split(':');
                        FirstDeliveryDateTime = new DateTime(
                            Convert.ToInt32(date[0]),
                            Convert.ToInt32(date[1]),
                            Convert.ToInt32(date[2]),
                            Convert.ToInt32(time[0]),
                            Convert.ToInt32(time[1]),
                            Convert.ToInt32(time[2])
                            );
                    }
                    catch { throw new ArgsParserException($"Invalid date time format {dateTimeS}"); }
                    break;
                case _deliveryLogArgName: DeliveryLog = CheckPath(args[++i]); break;
                case _deliveryOrderArgName: DeliveryOrder = CheckPath(args[++i]); break;
                default: throw new ArgsParserException($"Invalid parameter {args[i]}");
            }
        }
    }

    const string _cityDistrictArgName = "_cityDistrict";
    const string _firstDeliveryDateTimeArgName = "_firstDeliveryDateTime";
    const string _deliveryLogArgName = "_deliveryLog";
    const string _deliveryOrderArgName = "_deliveryOrder";

    public int? CityDistrict { get; }
    public DateTime? FirstDeliveryDateTime { get; }
    public string? FirstDeliveryDateTimeString { get => FirstDeliveryDateTime?.ToString("yyyy-MM-dd HH:mm:ss"); }
    public string? DeliveryLog { get; }
    public string? DeliveryOrder { get; }

    static string CheckPath(string path)
    {
        path = Path.GetFullPath(path);
        if (!Directory.Exists(path))
            throw new ArgsParserException($"Invalid path {path}");
        return path;
    }
}
