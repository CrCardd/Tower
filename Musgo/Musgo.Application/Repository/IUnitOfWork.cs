
namespace Musgo.Application.Repository;

public interface IUnitOfWork
{
    Task Save(CancellationToken cancellationToken);
}
