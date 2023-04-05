using System.Net;
using API.Core;
using MediatR;

namespace ReactivitiesV1.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class BaseApiController : ControllerBase
{
    private IMediator _mediator;
    protected IMediator Medaitor =>
     _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

    protected ActionResult HandleResponse<T>(Result<T> res)
    {
        if (!res.IsSuccess && res.Data is null)
        {
            res.code = (int)HttpStatusCode.NotFound;
            return NotFound(res);

        };
        if (res.IsSuccess && res.Data is not null)
        {
            res.code = (int)HttpStatusCode.OK;
            return Ok(res);
        }

        return BadRequest();
    }
}

