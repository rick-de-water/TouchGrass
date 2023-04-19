using System;
using System.Threading;
using System.Threading.Tasks;

namespace TouchGrass.Application.Database;

public interface IUnitOfWork : IAsyncDisposable
{
    IWeatherConditionRepository WeatherConditionRepository { get; }

    Task Commit(CancellationToken cancellationToken = default);
}