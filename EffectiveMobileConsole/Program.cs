using EffectiveMobileConsole.Models;
using EffectiveMobileConsole.Services;

try
{
    ArgsParser parser = new(args);
    if (parser.DeliveryLog is not null) LogService.LogPath = parser.DeliveryLog;

    List<Order> orders = OrderService.ReadOrders(@"orders.csv");
    orders = OrderService.FilterOrders(orders, parser.CityDistrict, parser.FirstDeliveryDateTime);
    OrderService.WriteOrders(orders, parser.DeliveryOrder ?? "");
}
catch (Exception ex)
{
    try
    {
        LogService.Log(new() { Level = LogEvent.LogLevels.Error, Message = ex.Message });
    }
    catch (Exception logEx)
    {
        PrintService.PrintErrorMessage($"LOG ERROR: {logEx.Message}");
    }
}

