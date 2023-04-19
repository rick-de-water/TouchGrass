using System;
using TouchGrass.Domain.Values;

namespace TouchGrass.Domain.Entities;

public record WeatherCondition
{
    public required DateTimeOffset ObservationDateTime { get; init; }
    public required Temperature PerceivedTemperature { get; init; }
    public required Temperature ActualTemperature { get; init; }
    public required Wind Wind { get; init; }
}
