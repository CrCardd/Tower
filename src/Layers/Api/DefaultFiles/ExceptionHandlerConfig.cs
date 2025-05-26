using Tower.Layers.Archives;

namespace Tower.Layers.Api.DefaultFiles;

public class ExceptionHandlerConfig : IFile
{
    public ExceptionHandlerConfig(string projectName) : base("ExceptionHandlerConfig")
    {
        this.Content =
@$"
using System.Text.Json;
using {projectName}.Application.Common.Exceptions;
using {projectName}.Domain.Common.Enums;
using {projectName}.Domain.Common.Messages;
using Microsoft.AspNetCore.Diagnostics;

namespace {projectName}.Api.Middlewares.ExceptionHandlers;

public static class ExceptionHandlerConfig
{{
    public static void UseErrorHandler(this IApplicationBuilder app) => 
        app.UseExceptionHandler(error => 
        {{
            error.Run(async context => 
            {{
                var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                if(contextFeature is null) return;

                var statusCode = contextFeature.Error switch
                {{
                    AppException appError => appError.StatusCode,
                    _ => StatusCode.InternalServerError
                }};
                var message = contextFeature.Error switch
                {{
                    AppException appError => appError.Message,
                    _ => ExceptionMessage.InternalServerError.Default
                }};

                context.Response.Headers.Append(""Access-Control-Allow-Origin"", ""*"");
                context.Response.ContentType = ""application/json"";
                context.Response.StatusCode = (int) statusCode;

                var errorResponse = new {{ statusCode, message }};

                await context.Response.WriteAsync(JsonSerializer.Serialize(errorResponse));
            }});
        }});
}} 
";
    }
}