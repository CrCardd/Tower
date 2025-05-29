
using Musgo.Domain.Common.Enums;
using Musgo.Domain.Common.Messages;

namespace Musgo.Application.Common.Exceptions;

public class NotFoundException(
    string message = ExceptionMessage.DuplicityModel.Default,
    string? details = null
) : AppException(StatusCode.NotFound, message, details) { }
