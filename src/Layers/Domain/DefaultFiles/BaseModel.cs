using Tower.Configuration;
using Tower.Layers.Archives;

namespace Tower.Layers.Domain.DefaultFiles;

public class BaseModel : IFile
{
    public BaseModel(string projectName) : base("BaseModel")
    {
        this.Content =
@$"
namespace {projectName}.Domain.Models;

public class BaseModel
{{
    public Guid Id {{ get; set; }} = Guid.NewGuid();
    public DateTime CreatedAt {{ get; set; }} = DateTime.UtcNow;
    public DateTime? UpdatedAt {{ get; set; }} = DateTime.UtcNow;
    public DateTime? DisabledAt {{ get; set; }} = null;
}}
";
    }
}
