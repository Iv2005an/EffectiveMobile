using EffectiveMobileConsole.Models;
using EffectiveMobileConsole.Services;

namespace EffectiveMobileTests;

public class OrdersServiceTest
{
    [Fact]
    public void TestFiltering()
    {
        List<Order> orders = [
            new(){Id = 0,CityDistrict = 0, DeliveryDateTime = new(2024, 10, 27, 12, 40, 0), Weight = 0},
            new(){Id = 1,CityDistrict = 0, DeliveryDateTime = new(2024, 10, 27, 12, 50, 0), Weight = 0},
            new(){Id = 2,CityDistrict = 0, DeliveryDateTime = new(2024, 10, 27, 12, 23, 0), Weight = 0},
            new(){Id = 3,CityDistrict = 0, DeliveryDateTime = new(2024, 10, 27, 12, 10, 0), Weight = 0},
            new(){Id = 4,CityDistrict = 0, DeliveryDateTime = new(2024, 10, 27, 12, 41, 0), Weight = 0},
            new(){Id = 5,CityDistrict = 0, DeliveryDateTime = new(2024, 10, 27, 12, 13, 0), Weight = 0},
            new(){Id = 6,CityDistrict = 0, DeliveryDateTime = new(2024, 10, 27, 12, 18, 0), Weight = 0},
            new(){Id = 7,CityDistrict = 1, DeliveryDateTime = new(2024, 10, 27, 12, 10, 0), Weight = 0},
            new(){Id = 8,CityDistrict = 1, DeliveryDateTime = new(2024, 10, 27, 12, 10, 0), Weight = 0},
            new(){Id = 9,CityDistrict = 1, DeliveryDateTime = new(2024, 10, 27, 12, 10, 0), Weight = 0},
            ];
        int cityDistrict = 0;
        DateTime firstDeliveryDateTime = new(2024, 10, 27, 12, 0, 0);
        List<Order> filteredOrders = OrderService.FilterOrders(orders, cityDistrict, firstDeliveryDateTime);
        List<Order> referencesfilteredOrders = [
            new(){Id = 2,CityDistrict = 0, DeliveryDateTime = new(2024, 10, 27, 12, 23, 0), Weight = 0},
            new(){Id = 3,CityDistrict = 0, DeliveryDateTime = new(2024, 10, 27, 12, 10, 0), Weight = 0},
            new(){Id = 5,CityDistrict = 0, DeliveryDateTime = new(2024, 10, 27, 12, 13, 0), Weight = 0},
            new(){Id = 6,CityDistrict = 0, DeliveryDateTime = new(2024, 10, 27, 12, 18, 0), Weight = 0},
            ];
        Assert.Equivalent(filteredOrders, referencesfilteredOrders);
    }
    [Fact]
    public void TestFiltering1()
    {
        List<Order> orders = [
            new(){Id = 0,CityDistrict = 0, DeliveryDateTime = new(2024, 10, 27, 12, 40, 0), Weight = 0},
            new(){Id = 1,CityDistrict = 0, DeliveryDateTime = new(2024, 10, 27, 12, 50, 0), Weight = 0},
            new(){Id = 2,CityDistrict = 0, DeliveryDateTime = new(2024, 10, 27, 12, 23, 0), Weight = 0},
            new(){Id = 3,CityDistrict = 0, DeliveryDateTime = new(2024, 10, 27, 12, 10, 0), Weight = 0},
            new(){Id = 4,CityDistrict = 0, DeliveryDateTime = new(2024, 10, 27, 12, 41, 0), Weight = 0},
            new(){Id = 5,CityDistrict = 0, DeliveryDateTime = new(2024, 10, 27, 12, 13, 0), Weight = 0},
            new(){Id = 6,CityDistrict = 0, DeliveryDateTime = new(2024, 10, 27, 12, 18, 0), Weight = 0},
            new(){Id = 7,CityDistrict = 1, DeliveryDateTime = new(2024, 10, 27, 12, 10, 0), Weight = 0},
            new(){Id = 8,CityDistrict = 1, DeliveryDateTime = new(2024, 10, 27, 12, 10, 0), Weight = 0},
            new(){Id = 9,CityDistrict = 1, DeliveryDateTime = new(2024, 10, 27, 12, 40, 0), Weight = 0},
            ];
        int cityDistrict = 1;
        DateTime firstDeliveryDateTime = new(2024, 10, 27, 12, 0, 0);
        List<Order> filteredOrders = OrderService.FilterOrders(orders, cityDistrict, firstDeliveryDateTime);
        List<Order> referencesfilteredOrders = [
            new(){Id = 7,CityDistrict = 1, DeliveryDateTime = new(2024, 10, 27, 12, 10, 0), Weight = 0},
            new(){Id = 8,CityDistrict = 1, DeliveryDateTime = new(2024, 10, 27, 12, 10, 0), Weight = 0},
            ];
        Assert.Equivalent(filteredOrders, referencesfilteredOrders);
    }
    [Fact]
    public void TestFiltering2()
    {
        List<Order> orders = [
            new(){Id = 0,CityDistrict = 0, DeliveryDateTime = new(2024, 10, 27, 12, 40, 0), Weight = 0},
            new(){Id = 1,CityDistrict = 0, DeliveryDateTime = new(2024, 10, 27, 12, 50, 0), Weight = 0},
            new(){Id = 2,CityDistrict = 0, DeliveryDateTime = new(2024, 10, 27, 12, 23, 0), Weight = 0},
            new(){Id = 3,CityDistrict = 0, DeliveryDateTime = new(2024, 10, 27, 12, 10, 0), Weight = 0},
            new(){Id = 4,CityDistrict = 0, DeliveryDateTime = new(2024, 10, 27, 12, 41, 0), Weight = 0},
            new(){Id = 5,CityDistrict = 0, DeliveryDateTime = new(2024, 10, 27, 12, 13, 0), Weight = 0},
            new(){Id = 6,CityDistrict = 0, DeliveryDateTime = new(2024, 10, 27, 12, 18, 0), Weight = 0},
            new(){Id = 7,CityDistrict = 1, DeliveryDateTime = new(2024, 10, 27, 12, 50, 0), Weight = 0},
            new(){Id = 8,CityDistrict = 1, DeliveryDateTime = new(2024, 10, 27, 12, 34, 0), Weight = 0},
            new(){Id = 9,CityDistrict = 1, DeliveryDateTime = new(2024, 10, 27, 12, 40, 0), Weight = 0},
            ];
        int cityDistrict = 1;
        DateTime firstDeliveryDateTime = new(2024, 10, 27, 12, 0, 0);
        List<Order> filteredOrders = OrderService.FilterOrders(orders, cityDistrict, firstDeliveryDateTime);
        Assert.Empty(filteredOrders);
    }
}
