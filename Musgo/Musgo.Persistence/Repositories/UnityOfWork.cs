
using System.ComponentModel;
using Musgo.Application.Repository;
using Musgo.Persistence.Context;

namespace Musgo.Persistence.Repositories;

public class UnitOfWork(MusgoContext ctx) : IUnitOfWork
{
    private readonly MusgoContext context = ctx;

    public Task Save(CancellationToken cancellationToken)
    {
        return context.SaveChangesAsync(cancellationToken);
    }
}
