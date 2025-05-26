using Tower.Layers.Archives;

namespace Tower.Layers.Application.Entities;

public class IBaseRepository : IFile
{
    public IBaseRepository(string projectName) : base("IBaseRepository")
    {
        this.Content =
@$"
using {projectName}.Domain.Models;

namespace {projectName}.Application.Repository;
public interface IBaseRepository<TEntity> 
    where TEntity : BaseModel
{{
    void Create(TEntity entity);
    void Update(TEntity entity);
    void Delete(TEntity entity);
    Task<bool> Exists(Guid id, CancellationToken cancellationToken);
    Task<TEntity?> Get(Guid id, CancellationToken cancellationToken);
    Task<List<TEntity>> GetAll(CancellationToken cancellationToken); 
}}
";
    }
}
