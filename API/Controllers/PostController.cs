using System.Net;
using API.Core;
using ReactivitiesV1.Domain;
using ReactivitiesV1.DTO;
using ReactivitiesV1.DTO.Post;
using ReactivitiesV1.Services;
using ReactivitiesV1.Services.Posts;

namespace ReactivitiesV1.Controllers;
public class PostsController : BaseApiController
{

    [HttpGet]
    public async Task<ActionResult<List<Post>>> GetAllPosts()
    {
        return await Medaitor.Send(new GetAll.Query());
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetOnePost(int id)
    {
        var res = await Medaitor.Send(new PostDetails.Query { Id = id });

        return HandleResponse(res);

    }
    [HttpPost("new")]
    public async Task<IActionResult> CreatePost(ModifyPost post)
    {
        return Ok(await Medaitor.Send(new CreatePost.Command { Post = post }));
    }
    [HttpPut("edit/{id}")]
    public async Task<IActionResult> EditPost(EditPostDto post, int id)
    {
        return Ok(await Medaitor.Send(new EditPost.Command { Post = post, Id = id }));
    }
    [HttpDelete("remove/{id}")]
    public async Task<IActionResult> DeletePost(int id)
    {
        return Ok(await Medaitor.Send(new RemovePost.Command { Id = id }));
    }
}
