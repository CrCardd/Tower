
using Musgo.Domain.Common.Enums;
using Musgo.Domain.Common.Messages;

namespace Musgo.Application.Common.Exceptions;

public class DuplicityException(
    string message = ExceptionMessage.DuplicityModel.Default,
    string? details = null
) : AppException(StatusCode.Conflict, message, details) { }
