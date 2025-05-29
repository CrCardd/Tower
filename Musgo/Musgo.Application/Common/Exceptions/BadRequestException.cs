
using Musgo.Domain.Common.Enums;
using Musgo.Domain.Common.Messages;

namespace Musgo.Application.Common.Exceptions;

public class BadRequestException(
    string message = ExceptionMessage.BadRequest.Default,
    string? details = null
) : AppException(StatusCode.BadRequest, message, details) { }
