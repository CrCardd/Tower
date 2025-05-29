
using MediatR;

namespace Musgo.Application.Features.Alternative.DeleteById;

public sealed record DeleteByIdAlternativeRequest(

) : IRequest<DeleteByIdAlternativeResponse>;
