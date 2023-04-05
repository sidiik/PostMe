using System.Net;
using API.Core;
using MediatR;
using Microsoft.AspNetCore.Http.Extensions;

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
        res.href = HttpContext.Request.GetDisplayUrl();
        res.StatusCode = HttpStatusCode.OK;
        if (res.IsSuccess && res.Data is not null)
        {
            return Ok(res);
        }
        if (!res.IsSuccess && res.Data is null)
        {
            res.StatusCode = HttpStatusCode.NotFound;
            return NotFound(res);
        }

        res.StatusCode = HttpStatusCode.BadRequest;
        return BadRequest();

    }
}

