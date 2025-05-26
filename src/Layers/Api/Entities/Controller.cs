using Tower.Configuration;
using Tower.Layers.Archives;

namespace Tower.Layers.Api.Entities;

public class Controller : IFile
{
    public Controller(string name) : base($"{name}Controller")
    {
        this.Content =
@$"
using {Config.ProjectName}.Api.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace {Config.ProjectName}.Api.Controllers;

[ApiController]
//[Route(APIRoutes.{name})]
public class {name}Controller(IMediator mediator) : ControllerBase
{{
    private readonly IMediator mediator = mediator;
    
    /*
    FORMAT EXAMPLE:
        -------------------------------------------------------------------------
        [Http[METHOD]]
        public async Task<ActionResult<[SERVICE]{name}Response>> [METHOD](
            [SERVICE]{name}Request request, CancellationToken cancellationToken
        )
        {{
            var response = await mediator.Send(request, cancellationToken);
            return [METHOD](APIRoutes.Categories, response);
        }}
        -------------------------------------------------------------------------
    */
}}
";
    }
}
