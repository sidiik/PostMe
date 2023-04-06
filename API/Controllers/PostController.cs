using API.Core;
using Microsoft.AspNetCore.Authorization;
using ReactivitiesV1.Domain;
using ReactivitiesV1.DTO;
using ReactivitiesV1.DTO.Post;
using ReactivitiesV1.Services;
using ReactivitiesV1.Services.Posts;

namespace ReactivitiesV1.Controllers;
public class PostsController : BaseApiController
{

    [AllowAnonymous]
    [HttpGet]
    public async Task<IActionResult> GetAllPosts()
    {
        var res = await Medaitor.Send(new GetAll.Query());

        return HandleResponse(res);

    }
    [AllowAnonymous]
    [HttpGet("{id}")]
    public async Task<ActionResult<Post>> GetOnePost(int id)
    {
        return HandleResponse(await Medaitor.Send(new PostDetails.Query { Id = id }));
    }
    [HttpPost("new")]
    public async Task<IActionResult> CreatePost(ModifyPost post)
    {
        return Ok(await Medaitor.Send(new CreatePost.Command { Post = post }));
    }
    [HttpPut("edit/{id}")]
    public async Task<IActionResult> EditPost(EditPostDto post, int id)
    {
        return HandleResponse(await Medaitor.Send(new EditPost.Command { Post = post, Id = id }));
    }
    [HttpDelete("remove/{id}")]
    public async Task<IActionResult> DeletePost(int id)
    {
        return HandleResponse(await Medaitor.Send(new RemovePost.Command { Id = id }));
    }
}
