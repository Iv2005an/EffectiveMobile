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
                    try { _cityDistrict = Convert.ToInt32(cityDistrictS); break; }
                    catch { throw new Exception($"ARGS ERROR: Invalid city district index{cityDistrictS}"); }
                case _firstDeliveryDateTimeArgName:
                    string dateTimeS = args[++i];
                    try { _firstDeliveryDateTime = DateTime.Parse(dateTimeS); }
                    catch { throw new Exception($"ARGS ERROR: Invalid date time format {dateTimeS}"); }
                    break;
                case _deliveryLogArgName: DeliveryLog = CheckPath(args[++i]); break;
                case _deliveryOrderArgName: DeliveryOrder = CheckPath(args[++i]); break;
                default: throw new Exception($"ARGS ERROR: Invalid parameter {args[i]}");
            }
        }
        if (_cityDistrict is null)
            throw new Exception($"ARGS ERROR: Required argument {_cityDistrictArgName} is missing");
        if (_firstDeliveryDateTime is null)
            throw new Exception($"ARGS ERROR: Required argument {_firstDeliveryDateTimeArgName} is missing");
    }

    const string _cityDistrictArgName = "_cityDistrict";
    const string _firstDeliveryDateTimeArgName = "_firstDeliveryDateTime";
    const string _deliveryLogArgName = "_deliveryLog";
    const string _deliveryOrderArgName = "_deliveryOrder";

    readonly int? _cityDistrict;
    readonly DateTime? _firstDeliveryDateTime;

    public int CityDistrict => _cityDistrict ?? 0;
    public DateTime FirstDeliveryDateTime => _firstDeliveryDateTime ?? DateTime.MinValue;
    public string? DeliveryLog { get; }
    public string? DeliveryOrder { get; }

    static string CheckPath(string path)
    {
        path = Path.GetFullPath(path);
        if (!Directory.Exists(path))
            throw new Exception($"ARGS ERROR: Invalid path: {path}");
        return path;
    }
}
