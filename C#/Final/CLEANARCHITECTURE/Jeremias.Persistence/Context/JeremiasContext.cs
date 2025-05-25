
using Microsoft.EntityFrameworkCore;
//using Jeremias.Persistence.Tables;

namespace Jeremias.Persistence.Context;

public class JeremiasContext(DbContextOptions<JeremiasContext> options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
