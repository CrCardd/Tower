
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Musgo.Application.Config;

namespace Musgo.Persistence.Context;


public class MusgoDbContextFactory : IDesignTimeDbContextFactory<MusgoContext>
{
    public MusgoContext CreateDbContext(string[] args)
    {
        DotEnv.Load();

        var optionsBuilder = new DbContextOptionsBuilder<MusgoContext>();

        optionsBuilder.UseMySql(
            DotEnv.Get("DATABASE_URL"),
            ServerVersion.AutoDetect(DotEnv.Get("DATABASE_URL"))
        );

        return new MusgoContext(optionsBuilder.Options);
    }
}
