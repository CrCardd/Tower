
using Musgo.Api.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Musgo.Api.Controllers;

[ApiController]
//[Route(APIRoutes.user)]
public class userController(IMediator mediator) : ControllerBase
{
    private readonly IMediator mediator = mediator;
    
    /*
    FORMAT EXAMPLE:
        -------------------------------------------------------------------------
        [Http[METHOD]]
        public async Task<ActionResult<[SERVICE]userResponse>> [METHOD](
            [SERVICE]userRequest request, CancellationToken cancellationToken
        )
        {
            var response = await mediator.Send(request, cancellationToken);
            return [METHOD](APIRoutes.Categories, response);
        }
        -------------------------------------------------------------------------
    */
}
