
using MediatR;

namespace Musgo.Application.Features.Alternative.GetById;

public sealed record GetByIdAlternativeRequest(

) : IRequest<GetByIdAlternativeResponse>;
