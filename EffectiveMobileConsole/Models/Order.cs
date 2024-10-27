using CsvHelper.Configuration.Attributes;

namespace EffectiveMobileConsole.Models;

public class Order
{
    [Index(0)]
    public required int Id { get; set; }

    [Index(1)]
    public required float Weight { get; set; }

    [Index(2)]
    public required int CityDistrict { get; set; }

    [Index(3), Format("yyyy-MM-dd HH:mm:ss")]
    public required DateTime DeliveryDateTime { get; set; }
}
