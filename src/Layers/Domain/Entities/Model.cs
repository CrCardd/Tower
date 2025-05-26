using Tower.Configuration;
using Tower.Layers.Archives;

namespace Tower.Layers.Domain.Entities;

public class Model : IFile
{
    public Model(string name) : base(name)
    {
        this.Content =
@$"
﻿namespace {Config.ProjectName}.Domain.Models;

public class {name} : BaseModel
{{
}}
";
    }
}
