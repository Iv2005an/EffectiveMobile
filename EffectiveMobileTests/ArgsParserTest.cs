using EffectiveMobileConsole.Services;

namespace EffectiveMobileTests;

public class ArgsParserTest
{
    [Fact]
    public void TestParsing_ValidArguments()
    {
        string cityDistrict = "1";
        string firstDeliveryDateTime = "2024-10-25 14:34:23";
        string deliveryLog = "C:\\";
        string deliveryOrder = "C:\\";
        ArgsParser parser = new([
            "_cityDistrict", cityDistrict,
            "_firstDeliveryDateTime", firstDeliveryDateTime,
            "_deliveryLog", deliveryLog,
            "_deliveryOrder", deliveryOrder,]);
        Assert.Equal(cityDistrict, parser.CityDistrict.ToString());
        Assert.Equal(firstDeliveryDateTime, parser.FirstDeliveryDateTime.ToString("yyyy-MM-dd HH:mm:ss"));
        Assert.Equal(deliveryLog, parser.DeliveryLog);
        Assert.Equal(deliveryOrder, parser.DeliveryOrder);
    }
    [Fact]
    public void TestParsing_ValidArguments1()
    {
        string cityDistrict = "1";
        string firstDeliveryDateTime = "2024-10-25 14:34:23";
        string deliveryLog = @"..";
        string deliveryOrder = "C:\\";
        ArgsParser parser = new([
            "_cityDistrict", cityDistrict,
            "_firstDeliveryDateTime", firstDeliveryDateTime,
            "_deliveryLog", deliveryLog,
            "_deliveryOrder", deliveryOrder,]);
        Assert.Equal(cityDistrict, parser.CityDistrict.ToString());
        Assert.Equal(firstDeliveryDateTime, parser.FirstDeliveryDateTime.ToString("yyyy-MM-dd HH:mm:ss"));
        Assert.Equal(Path.GetFullPath(deliveryLog), parser.DeliveryLog);
        Assert.Equal(deliveryOrder, parser.DeliveryOrder);
    }
    [Fact]
    public void TestParsing_SkipRequiredArgument() =>
    Assert.Throws<Exception>(() =>
    {
        string cityDistrict = "1";
        string deliveryLog = "C:\\";
        string deliveryOrder = "C:\\";
        ArgsParser parser = new([
            "_cityDistrict", cityDistrict,
            "_deliveryLog", deliveryLog,
            "_deliveryOrder", deliveryOrder,]);
    });
    [Fact]
    public void TestParsing_InvalidÑityDistrict() =>
    Assert.Throws<Exception>(() =>
    {
        string firstDeliveryDateTime = "2024-10-25 23:34:23";
        string deliveryLog = "C:\\";
        string deliveryOrder = "C:\\";
        ArgsParser parser = new([
            "_cityDistrict",
            "_firstDeliveryDateTime", firstDeliveryDateTime,
            "_deliveryLog", deliveryLog,
            "_deliveryOrder", deliveryOrder,]);
    });
    [Fact]
    public void TestParsing_InvalidDateTime() =>
    Assert.Throws<Exception>(() =>
    {
        string cityDistrict = "1";
        string firstDeliveryDateTime = "2024-10-25 24:34:23";
        string deliveryLog = "C:\\";
        string deliveryOrder = "C:\\";
        ArgsParser parser = new([
            "_cityDistrict", cityDistrict,
            "_firstDeliveryDateTime", firstDeliveryDateTime,
            "_deliveryLog", deliveryLog,
            "_deliveryOrder", deliveryOrder,]);
    });
    [Fact]
    public void TestParsing_InvalidPath() =>
    Assert.Throws<Exception>(() =>
    {
        string cityDistrict = "1";
        string firstDeliveryDateTime = "2024-10-25 23:34:23";
        string deliveryLog = "Q:\\";
        string deliveryOrder = "W:\\";
        ArgsParser parser = new([
            "_cityDistrict", cityDistrict,
            "_firstDeliveryDateTime", firstDeliveryDateTime,
            "_deliveryLog", deliveryLog,
            "_deliveryOrder", deliveryOrder,]);
    });
}