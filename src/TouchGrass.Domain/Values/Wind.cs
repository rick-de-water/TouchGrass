namespace TouchGrass.Domain.Values;

public record Wind
{
    public required decimal Speed { get; init; }
    public required int Angle { get; init; }
}
