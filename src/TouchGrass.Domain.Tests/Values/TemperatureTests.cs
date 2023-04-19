using Shouldly;
using System.Linq;

namespace TouchGrass.Domain.Values;

public class TemperatureTests
{
    [Fact]
    public void CanCreateFromCelcius()
    {
        foreach (var celcius in Enumerable
            .Range(-10000, 10000)
            .Select(i => i / 100m))
        {
            var temperature = Temperature.FromCelcius(celcius);
            temperature.Celcius.ShouldBe(celcius);
        }
    }

    [Fact]
    public void CanCreateFormFahrenheit()
    {
        foreach (var fahrenheit in Enumerable
            .Range(-10000, 10000)
            .Select(i => i / 100m))
        {
            var temperature = Temperature.FromFahrenheit(fahrenheit);
            temperature.Fahrenheit.ShouldBe(fahrenheit);
        }
    }

    [Fact]
    public void CanConvertCelciusToFarenheit()
    {
        Temperature.FromCelcius(0).Fahrenheit.ShouldBe(32);
        Temperature.FromCelcius(100).Fahrenheit.ShouldBe(212);
        Temperature.FromCelcius(13.8m).Fahrenheit.ShouldBe(56.84m);
        Temperature.FromCelcius(-118).Fahrenheit.ShouldBe(-180.4m);
    }

    [Fact]
    public void CanConvertFarenheitToCelcius()
    {
        Temperature.FromFahrenheit(32).Celcius.ShouldBe(0);
        Temperature.FromFahrenheit(212).Celcius.ShouldBe(100);
        Temperature.FromFahrenheit(56.84m).Celcius.ShouldBe(13.8m);
        Temperature.FromFahrenheit(-180.4m).Celcius.ShouldBe(-118);
    }

    [Fact]
    public void CanBeCompared()
    {
        Temperature.FromCelcius(0).ShouldBeLessThan(Temperature.FromCelcius(12));
        Temperature.FromCelcius(27).ShouldBeGreaterThan(Temperature.FromCelcius(12));
    }
}
