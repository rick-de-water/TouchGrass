using System.Threading;
using System.Threading.Tasks;

namespace TouchGrass.Application.Database;

public interface IDatabase
{
    public Task<IUnitOfWork> CreateUnitOfWork(CancellationToken cancellationToken = default);
}
