using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TouchGrass.Domain.Entities;

namespace TouchGrass.Application.Database;

public interface IWeatherConditionRepository
{
    Task<WeatherCondition?> Find(DateTime when, CancellationToken cancellationToken = default);
    IAsyncEnumerable<WeatherCondition> GetAll(int? offset = null, int? count = null, CancellationToken cancellationToken = default);
}
