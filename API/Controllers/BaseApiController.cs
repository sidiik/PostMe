using MediatR;

namespace ReactivitiesV1.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class BaseApiController : ControllerBase
{
    private IMediator _mediator;
    protected IMediator Medaitor =>
     _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
}

