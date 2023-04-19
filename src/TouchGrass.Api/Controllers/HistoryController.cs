using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using TouchGrass.Api.Dtos;
using TouchGrass.Application.Database;
using TouchGrass.Domain.Entities;

namespace TouchGrass.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class HistoryController : ControllerBase
{
    public HistoryController(IDatabase database)
    {
        _database = database;
    }

    [HttpGet]
    public async IAsyncEnumerable<HistoryDto> GetAll(int? offset = null, int? count = 0, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        await using var unitOfWork = await _database.CreateUnitOfWork(cancellationToken);
        var repository = unitOfWork.WeatherConditionRepository;

        await foreach (var weatherCondition in repository.GetAll(offset, count, cancellationToken))
        {
            yield return ToDto(weatherCondition);
        }
    }

    [HttpGet]
    [Route("{when}")]
    public async Task<IActionResult> GetOnDate(DateTime when, CancellationToken cancellationToken)
    {
        await using var unitOfWork = await _database.CreateUnitOfWork(cancellationToken);
        var repository = unitOfWork.WeatherConditionRepository;

        var weatherCondition = await unitOfWork.WeatherConditionRepository.Find(when);
        if (weatherCondition == null)
        {
            return NotFound();
        }

        return Ok(ToDto(weatherCondition));
    }

    // TODO: create seperate mapper
    private HistoryDto ToDto(WeatherCondition weatherCondition)
    {
        return new HistoryDto
        {
            ObservationDateTime = weatherCondition.ObservationDateTime,
            Temperature = weatherCondition.ActualTemperature.Celcius,
            WindSpeed = weatherCondition.Wind.Speed,
            WindDirection = weatherCondition.Wind.Angle
        };
    }

    private IDatabase _database;
}
