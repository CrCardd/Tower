
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Jeremias.Application.Config;

namespace Jeremias.Persistence.Context;


public class JeremiasDbContextFactory : IDesignTimeDbContextFactory<JeremiasContext>
{
    public JeremiasContext CreateDbContext(string[] args)
    {
        DotEnv.Load();

        var optionsBuilder = new DbContextOptionsBuilder<JeremiasContext>();

        optionsBuilder.UseMySql(
            DotEnv.Get("DATABASE_URL"),
            ServerVersion.AutoDetect(DotEnv.Get("DATABASE_URL"))
        );

        return new JeremiasContext(optionsBuilder.Options);
    }
}
