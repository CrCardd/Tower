using Tower.Layers.Archives;

namespace Tower.Layers.Application.Files;

public class BadRequestException : IFile
{
    public BadRequestException(string projectName) : base("BadRequestException")
    {
        this.Content =
@$"
using {projectName}.Domain.Common.Enums;
using {projectName}.Domain.Common.Messages;

namespace {projectName}.Application.Common.Exceptions;

public class BadRequestException(
    string message = ExceptionMessage.BadRequest.Default,
    string? details = null
) : AppException(StatusCode.BadRequest, message, details) {{ }}
";
    }
}
