
using Microsoft.EntityFrameworkCore;
using Musgo.Persistence.Context;
using Musgo.Domain.Models;
using Musgo.Application.Repository;

namespace Musgo.Persistence.Repositories;

public class BaseRepository<TModel>(MusgoContext Context) : IBaseRepository<TModel>
    where TModel : BaseModel
{
    protected readonly MusgoContext context = Context;
    protected readonly DbSet<TModel> dbSet = Context.Set<TModel>();

    public void Create(TModel entity)
        => context.Add(entity);

    public void Update(TModel entity)
        => context.Update(entity);

    public void Delete(TModel entity)
    {
        entity.DisabledAt = DateTime.UtcNow;
        context.Update(entity);
    }

    public Task<TModel?> Get(Guid id, CancellationToken cancellationToken)
        => context
            .Set<TModel>()
            .Where(entity => entity.DisabledAt == null)
            .FirstOrDefaultAsync(entity => entity.Id == id, cancellationToken);

    public Task<List<TModel>> GetAll(CancellationToken cancellationToken)
        => context
            .Set<TModel>()
            .Where(entity => entity.DisabledAt == null)
            .ToListAsync(cancellationToken);

    public Task<bool> Exists(Guid id, CancellationToken cancellationToken)
        => dbSet.AnyAsync(e =>
            EF.Property<Guid>(e, "Id") == id &&
            EF.Property<Guid?>(e, "DisabledAt") == null,
            cancellationToken
        );
}
