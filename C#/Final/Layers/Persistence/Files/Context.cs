using Tower.Layers.Archives;

namespace Tower.Layers.Persistence.Files;

public class Context : IFile
{
    public Context(string projectName) : base($"{projectName}Context")
    {
        this.Content =
@$"
using Microsoft.EntityFrameworkCore;
//using {projectName}.Persistence.Tables;

namespace {projectName}.Persistence.Context;

public class {projectName}Context(DbContextOptions<{projectName}Context> options) : DbContext(options)
{{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {{
        base.OnModelCreating(modelBuilder);
    }}
}}
";
    }
}
