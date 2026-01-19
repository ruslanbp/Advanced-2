using Advanced.Tasks.LanguagePatterns;
using Xunit;

namespace Advanced.Tests.Tasks;

public class LanguagePatternsTasksTests
{
    private readonly LanguagePatternsTasks _sut = new();

    [Fact]
    public void GetObjectTypeNull_ReturnsNull()
    {
        var result = _sut.GetObjectType(null);
        Assert.Equal("Null", result);
    }

    [Fact]
    public void GetObjectTypeString_ReturnsString()
    {
        var result = _sut.GetObjectType("hello");
        Assert.Equal("String", result);
    }

    [Fact]
    public void GetObjectTypeInteger_ReturnsInteger()
    {
        var result = _sut.GetObjectType(42);
        Assert.Equal("Integer", result);
    }

    [Fact]
    public void GetObjectTypeBoolean_ReturnsBoolean()
    {
        var result = _sut.GetObjectType(true);
        Assert.Equal("Boolean", result);
    }

    [Fact]
    public void GetObjectTypeDouble_ReturnsDouble()
    {
        var result = _sut.GetObjectType(3.14);
        Assert.Equal("Double", result);
    }

    [Fact]
    public void GetObjectTypeFloat_ReturnsFloat()
    {
        var result = _sut.GetObjectType(2.50);
        Assert.Equal("Float", result);
    }

    [Fact]
    public void GetObjectTypeUnknownType_ReturnsUnknown()
    {
        var result = _sut.GetObjectType(new object());
        Assert.Equal("Unknown", result);
    }

    [Fact]
    public void CalculateShippingCostStandard_ReturnsFixedCost()
    {
        var result = _sut.CalculateShippingCost("standard", 10m);
        Assert.Equal(10m, result);
    }

    [Fact]
    public void CalculateShippingCostExpress_ReturnsWeightBasedCost()
    {
        var result = _sut.CalculateShippingCost("express", 4m);
        Assert.Equal(20.0m + 4m * 0.5m, result);
    }

    [Fact]
    public void CalculateShippingCostUnknownType_ReturnsZero()
    {
        var result = _sut.CalculateShippingCost("rocket", 1m);
        Assert.Equal(0.0m, result);
    }

    [Fact]
    public void CalculateShippingCostNullType_ReturnsZero()
    {
        var result = _sut.CalculateShippingCost(null, 1m);
        Assert.Equal(0.0m, result);
    }


    [Fact]
    public void GetProductStatusNullProduct_ReturnsInvalidMessage()
    {
        var result = _sut.GetProductStatus(null);
        Assert.Equal("Недопустимый товар", result);
    }

    [Fact]
    public void GetProductStatusPriceOver1000_ReturnsExpensive()
    {
        var product = new Product { Name = "TV", Price = 1500m, Stock = 5 };
        var result = _sut.GetProductStatus(product);
        Assert.Equal("Дорогой товар", result);
    }

    [Fact]
    public void GetProductStatusZeroStock_ReturnsOutOfStock()
    {
        var product = new Product { Name = "Phone", Price = 800m, Stock = 0 };
        var result = _sut.GetProductStatus(product);
        Assert.Equal("Нет в наличии", result);
    }

    [Fact]
    public void GetProductStatusNonPositivePrice_ReturnsInvalidPrice()
    {
        var product = new Product { Name = "Gift", Price = -10m, Stock = 10 };
        var result = _sut.GetProductStatus(product);
        Assert.Equal("Некорректная цена", result);
    }

    [Fact]
    public void GetProductStatusValidProduct_ReturnsAvailable()
    {
        var product = new Product { Name = "Book", Price = 200m, Stock = 3 };
        var result = _sut.GetProductStatus(product);
        Assert.Equal("В наличии", result);
    }
}