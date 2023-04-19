using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;
using TouchGrass.Api.Dtos;
using TouchGrass.Application.Database;
using TouchGrass.Domain.Values;

namespace TouchGrass.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TouchabilityController : ControllerBase
{
    public TouchabilityController(IDatabase database)
    {
        _database = database;
    }

    [HttpGet]
    public async Task<IActionResult> Get(CancellationToken cancellationToken)
    {
        await using var unitOfWork = await _database.CreateUnitOfWork(cancellationToken);
        var repository = unitOfWork.WeatherConditionRepository;

        var currentCondition = await repository.Find(DateTime.UtcNow, cancellationToken);
        if (currentCondition == null)
        {
            return NotFound();
        }

        if (currentCondition.PerceivedTemperature > Temperature.FromCelcius(18))
        {
            return Ok(new TouchabilityDto
            {
                IsTouchable = true,
                Message = "Go touch some grass!"
            });
        }
        else
        {
            return Ok(new TouchabilityDto
            {
                IsTouchable = false,
                Message = "Better stay inside..."
            });
        }
    }

    private IDatabase _database;
}
