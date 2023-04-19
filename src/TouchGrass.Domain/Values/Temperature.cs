using System;

namespace TouchGrass.Domain.Values;

public readonly record struct Temperature : IComparable<Temperature>
{
    public static Temperature FromCelcius(decimal celcius)
    {
        return new Temperature
        {
            Celcius = celcius
        };
    }

    public static Temperature FromFahrenheit(decimal fahrenheit)
    {
        return FromCelcius((fahrenheit - 32m) * 5m / 9m);
    }

    public decimal Celcius { get; init; } 
    public decimal Fahrenheit => Celcius * 9m / 5m + 32m;

    public override string ToString()
    {
        // TODO: Use CultureInfo to select temperature unit
        return $"{Celcius} °C";
    }

    public int CompareTo(Temperature other)
    {
        return Celcius.CompareTo(other.Celcius);
    }

    public static bool operator < (Temperature left, Temperature right) => left.CompareTo(right) < 0;
    public static bool operator > (Temperature left, Temperature right) => left.CompareTo(right) > 0;
    public static bool operator <= (Temperature left, Temperature right) => left.CompareTo(right) <= 0;
    public static bool operator >= (Temperature left, Temperature right) => left.CompareTo(right) >= 0;
}
