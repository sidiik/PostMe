using System.Net;
using API.Core;
using API.Domain;
using API.DTO.User;
using API.helpers;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Identity;

namespace API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class AccountController : ControllerBase
{
    private readonly UserManager<AppUser> _userManager;
    private readonly TokenService _token;
    public AccountController(UserManager<AppUser> userManager, TokenService token)
    {
        _token = token;
        _userManager = userManager;

    }

    [HttpPost("login")]
    public async Task<ActionResult<AccountResult<UserDTO>>> Login(LoginDto userLogin)
    {
        var user = await _userManager.FindByEmailAsync(userLogin.Email);

        if (user is null)
        {

            return Unauthorized(AccountResult<UserDTO>.Failure("Email or password is wrong"));
        }

        var result = await _userManager.CheckPasswordAsync(user, userLogin.Password);

        if (!result)
            return Unauthorized(AccountResult<UserDTO>.Failure("Email or password is wrong"));

        var userResult = new UserDTO
        {

            Username = user.UserName,
            Token = _token.GenerateToken(user),
            Image = null,
            DisplayName = user.DisplayName
        };

        return AccountResult<UserDTO>.Success(userResult);

    }

}

