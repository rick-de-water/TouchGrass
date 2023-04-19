namespace TouchGrass.Api.Dtos;

public record TouchabilityDto
{
    public required bool IsTouchable { get; init; }
    public required string Message { get; init; }
}
