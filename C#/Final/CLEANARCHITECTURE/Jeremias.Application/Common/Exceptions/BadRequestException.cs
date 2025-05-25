
using Jeremias.Domain.Common.Enums;
using Jeremias.Domain.Common.Messages;

namespace Jeremias.Application.Common.Exceptions;

public class BadRequestException(
    string message = ExceptionMessage.BadRequest.Default,
    string? details = null
) : AppException(StatusCode.BadRequest, message, details) { }
