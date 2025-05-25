using Tower.Layers.Archives;

namespace Tower.Layers.Api.Files;

public class CorsPolicyExtension : IFile
{
    public CorsPolicyExtension(string projectName) : base("CorsPolicyExtension")
    {
        this.Content =
@$"
namespace Iduca.Api.Extensions;

public static class CorsPolicyExtensions
{{
    public static void ConfigureCorsPolicy(this IServiceCollection services)
    {{
        services.AddCors(opt =>
            opt.AddDefaultPolicy((builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
            )
        ));
    }}
}}
";
    }
}