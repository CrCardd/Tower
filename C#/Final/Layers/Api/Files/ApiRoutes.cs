using Tower.Layers.Archives;

namespace Tower.Layers.Api.Files;

public class ApiRoutes : IFile
{
    public ApiRoutes(string projectName) : base("ApiRoutes")
    {
        this.Content =
this.Content =
@$"
namespace {projectName}.Api.Enums;
public static class APIRoutes
{{
    /* 
        public const string RouteName = ""api/controllerRoute"";
    */
}}
";
    }
}

