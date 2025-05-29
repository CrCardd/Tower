
﻿using Musgo.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Musgo.Persistence.Tables;

public static class userClassMap
{
    public static void ConfigureuserTable(this ModelBuilder modelBuilder)
        => modelBuilder.Entity<user>(builder =>
    {
        builder.ConfigurBaseTableProps();

        builder.HasKey(user => user.Id)
            .HasName("user_id");

        builder.ToTable("tb_user");
    });
}
