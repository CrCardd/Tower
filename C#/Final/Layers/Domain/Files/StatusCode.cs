using Tower.Layers.Archives;

namespace Tower.Layers.Domain.Files;

public class StatusCode : IFile
{
    public StatusCode(string projectName) : base("StatusCode")
    {
        this.Content =
@$"
namespace {projectName}.Domain.Common.Enums;

public enum StatusCode
{{
    BadRequest = 400,
    Unauthorized = 401,
    Forbidden = 403,
    NotFound = 404,
    Conflict = 409,
    ImATeapot = 418,
    InternalServerError = 500,
    NotImplemented = 501,
}}
";
    }
}
