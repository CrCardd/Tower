using Tower.Configuration;
using Tower.Layers.Archives;

namespace Tower.Layers.Persistence.Entities;

public class Table : IFile
{
    public Table(string name) : base($"{name}ClassMap")
    {
        this.Content =
@$"
﻿using {Config.ProjectName}.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace {Config.ProjectName}.Persistence.Tables;

public static class {name}ClassMap
{{
    public static void Configure{name}Table(this ModelBuilder modelBuilder)
        => modelBuilder.Entity<{name}>(builder =>
    {{
        builder.ConfigurBaseTableProps();

        builder.HasKey({name.ToLower()} => {name.ToLower()}.Id)
            .HasName(""{name.ToLower()}_id"");

        builder.ToTable(""tb_{name.ToLower()}"");
    }});
}}
";
    }
}
