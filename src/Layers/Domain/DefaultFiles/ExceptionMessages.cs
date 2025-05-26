using Tower.Layers.Archives;

namespace Tower.Layers.Domain.DefaultFiles;

public class ExceptionMessages : IFile
{
    public ExceptionMessages(string projectName) : base("ExceptionMessages")
    {
        this.Content =
@$"
namespace {projectName}.Domain.Common.Messages;

public static class ExceptionMessage
{{
    public static class BadRequest
    {{
        public const string Default = ""Bad request"";
    }}

    public static class DuplicityModel
    {{
        public const string Default = ""It's already exists!"";
    }}

    public static class InternalServerError
    {{
        public const string Default = ""Internal server error"";
    }}

    public static class NotFound
    {{
        public const string Default = ""Item not found"";
    }}
}}
";
    }
}
