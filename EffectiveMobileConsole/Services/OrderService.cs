using CsvHelper;
using EffectiveMobileConsole.Models;
using System.Globalization;

namespace EffectiveMobileConsole.Services;

public static class OrderService
{
    public static List<Order> ReadOrders(string path)
    {
        List<Order> orders = [];
        try
        {
            path = Path.GetFullPath(path);
            using StreamReader reader = new(path);
            using CsvReader csv = new(reader, CultureInfo.InvariantCulture);
            orders = csv.GetRecords<Order>().ToList();
        }
        catch (Exception ex)
        {
            throw new Exception($"READ ORDERS ERROR: {ex.Message}");
        }
        LogService.Log(new()
        {
            Level = LogEvent.LogLevels.Info,
            Message = $"Received {orders.Count} orders from path: {path}",
        });
        return orders;
    }

    public static void WriteOrders(IEnumerable<Order> orders, string path)
    {
        try
        {
            path = Path.GetFullPath(Path.Combine(path, "filtered_orders.csv"));
            using StreamWriter writer = new(path);
            using CsvWriter csv = new(writer, CultureInfo.InvariantCulture);
            csv.WriteRecords(orders);
        }
        catch (Exception ex)
        {
            throw new Exception($"WRITE ORDERS ERROR: {ex.Message}");
        }
        LogService.Log(new()
        {
            Level = LogEvent.LogLevels.Info,
            Message = $"Recorded {orders.Count()} orders to path: {path}",
        });
    }

    public static List<Order> FilterOrders(
        IEnumerable<Order> orders, int cityDistrict, DateTime firstDeliveryDateTime)
    {
        List<Order> filteredOrders = orders.Where(o => o.CityDistrict == cityDistrict
            && o.DeliveryDateTime >= firstDeliveryDateTime
            && o.DeliveryDateTime <= firstDeliveryDateTime.AddMinutes(30)
        ).ToList();
        LogService.Log(new()
        {
            Level = LogEvent.LogLevels.Info,
            Message = $"Filtered {filteredOrders.Count} orders by city district: {cityDistrict} and first delivery date time: {firstDeliveryDateTime:yyyy-MM-dd HH:mm:ss}",
        });
        return filteredOrders;
    }
}
