
using ReactivitiesV1.Data;
using ReactivitiesV1.Domain;
using ReactivitiesV1.Services;

namespace ReactivitiesV1.Controllers;
public class PostsController : BaseApiController
{

    [HttpGet]
    public async Task<ActionResult<List<Post>>> GetAllPosts()
    {
        return await Medaitor.Send(new GetAll.Query());
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<Post>> GetOnePost(int id)
    {
        return await Medaitor.Send(new PostDetails.Query { Id = id });
    }
}
