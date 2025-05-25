using Tower.Layers.Archives;

namespace Tower.Layers.Application.Files;

public class NotFoundException : IFile
{
    public NotFoundException(string projectName) : base("NotFoundException")
    {
        this.Content =
@$"
using {projectName}.Domain.Common.Enums;
using {projectName}.Domain.Common.Messages;

namespace {projectName}.Application.Common.Exceptions;

public class NotFoundException(
    string message = ExceptionMessage.DuplicityModel.Default,
    string? details = null
) : AppException(StatusCode.NotFound, message, details) {{ }}
";
    }
}
