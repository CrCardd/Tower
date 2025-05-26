using Tower.Layers.Archives;

namespace Tower.Layers.Application.DefaultFiles;

public class DuplicityException : IFile
{
    public DuplicityException(string projectName) : base("DuplicityException")
    {
        this.Content =
@$"
using {projectName}.Domain.Common.Enums;
using {projectName}.Domain.Common.Messages;

namespace {projectName}.Application.Common.Exceptions;

public class DuplicityException(
    string message = ExceptionMessage.DuplicityModel.Default,
    string? details = null
) : AppException(StatusCode.Conflict, message, details) {{ }}
";
    }
}
