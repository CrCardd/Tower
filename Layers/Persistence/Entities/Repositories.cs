using Tower.Configuration;
using Tower.Layers.Archives;

namespace Tower.Layers.Persistence.Entities;

public class Repositories : IFile
{
    public Repositories(string name) : base($"{name}Repository")
    {
        this.Content =
@$"
﻿using {Config.ProjectName}.Application.Repository.{name}Repository;
using {Config.ProjectName}.Domain.Models;
using {Config.ProjectName}.Persistence.Context;

namespace {Config.ProjectName}.Persistence.Repositories.{name}_;

public class {name}Repository({Config.ProjectName}Context context)
    : BaseRepository<{name}>(context), I{name}Repository
{{
    
}}
";
    }
}
