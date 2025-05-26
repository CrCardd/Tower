using Tower.Layers.Archives;

namespace Tower.Layers.Application.DefaultFiles;

public class AppException : IFile
{
    public AppException(string projectName) : base("AppException")
    {
        this.Content =
@$"
using {projectName}.Domain.Common.Enums;

namespace {projectName}.Application.Common.Exceptions;

public class AppException(
    StatusCode statusCode,
    string message,
    string? details = null
) : Exception(message)
{{
    public StatusCode StatusCode {{ get; }} = statusCode;
    public string? Details {{ get; }} = details;
}}
";
    }
}
