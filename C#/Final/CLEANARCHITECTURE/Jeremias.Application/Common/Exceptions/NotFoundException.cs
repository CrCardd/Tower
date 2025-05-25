
using Jeremias.Domain.Common.Enums;
using Jeremias.Domain.Common.Messages;

namespace Jeremias.Application.Common.Exceptions;

public class NotFoundException(
    string message = ExceptionMessage.DuplicityModel.Default,
    string? details = null
) : AppException(StatusCode.NotFound, message, details) { }
