using Tower.Layers.Archives;

namespace Tower.Layers.Application.DefaultFiles;

public class ServiceExtension : IFile
{
    public ServiceExtension(string projectName) : base("ServiceExtension")
    {
        this.Content =
@$"
using System.Reflection;
using {projectName}.Application.Common.Exceptions;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using {projectName}.Application.Common.Behaviors;

namespace {projectName}.Application;

public static class ServiceExtensions
{{
    public static void ConfigureApplication(this IServiceCollection services)
    {{
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
    }}
}}
";
    }
}