using Tower.Layers.Archives;

namespace Tower.Layers.Persistence.Files;

public class ContextFactory : IFile
{
    public ContextFactory(string projectName) : base($"{projectName}ContextFactory")
    {
        this.Content =
@$"
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using {projectName}.Application.Config;

namespace {projectName}.Persistence.Context;


public class {projectName}DbContextFactory : IDesignTimeDbContextFactory<{projectName}Context>
{{
    public {projectName}Context CreateDbContext(string[] args)
    {{
        DotEnv.Load();

        var optionsBuilder = new DbContextOptionsBuilder<{projectName}Context>();

        optionsBuilder.UseMySql(
            DotEnv.Get(""DATABASE_URL""),
            ServerVersion.AutoDetect(DotEnv.Get(""DATABASE_URL""))
        );

        return new {projectName}Context(optionsBuilder.Options);
    }}
}}
";
    }
}
