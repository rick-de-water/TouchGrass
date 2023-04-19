using System;
using TouchGrass.Domain.Values;

namespace TouchGrass.Api.Dtos;

public record HistoryDto
{
    public required DateTimeOffset ObservationDateTime { get; init; }
    public required decimal Temperature { get; init; }
    public required decimal WindSpeed { get; init; }
    public required int WindDirection { get; init; }
}
