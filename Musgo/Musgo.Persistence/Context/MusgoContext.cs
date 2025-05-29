
using Microsoft.EntityFrameworkCore;
//using Musgo.Persistence.Tables;

namespace Musgo.Persistence.Context;

public class MusgoContext(DbContextOptions<MusgoContext> options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
