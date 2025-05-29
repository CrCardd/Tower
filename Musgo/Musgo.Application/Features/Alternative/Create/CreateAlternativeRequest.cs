
using MediatR;

namespace Musgo.Application.Features.Alternative.Create;

public sealed record CreateAlternativeRequest(

) : IRequest<CreateAlternativeResponse>;
